using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiSaleRequestModelValidator : AbstractValidator<ApiSaleRequestModel>
	{
		private int existingRecordId;

		private ISaleRepository saleRepository;

		public AbstractApiSaleRequestModelValidator(ISaleRepository saleRepository)
		{
			this.saleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void IpAddressRules()
		{
			this.RuleFor(x => x.IpAddress).NotNull();
			this.RuleFor(x => x.IpAddress).Length(0, 128);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull();
			this.RuleFor(x => x.Note).Length(0, 2147483647);
		}

		public virtual void SaleDateRules()
		{
		}

		public virtual void TransactionIdRules()
		{
			this.RuleFor(x => x.TransactionId).MustAsync(this.BeValidTransactionByTransactionId).When(x => x?.TransactionId != null).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTransactionByTransactionId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleRepository.TransactionByTransactionId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>c79c1ef837119222d5766f1b1f545404</Hash>
</Codenesium>*/