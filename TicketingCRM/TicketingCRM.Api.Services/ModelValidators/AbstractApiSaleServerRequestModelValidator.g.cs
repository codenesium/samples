using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>
	{
		private int existingRecordId;

		private ISaleRepository saleRepository;

		public AbstractApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.saleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
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
			this.RuleFor(x => x.TransactionId).MustAsync(this.BeValidTransactionByTransactionId).When(x => !x?.TransactionId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference");
		}

		private async Task<bool> BeValidTransactionByTransactionId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.saleRepository.TransactionByTransactionId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>fbb1b3cf13c55e2109b600e8a3689d9f</Hash>
</Codenesium>*/