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
	public abstract class AbstractApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public AbstractApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void IpAddressRules()
		{
			this.RuleFor(x => x.IpAddress).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.IpAddress).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NoteRules()
		{
			this.RuleFor(x => x.Note).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Note).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void SaleDateRules()
		{
		}

		public virtual void TransactionIdRules()
		{
			this.RuleFor(x => x.TransactionId).MustAsync(this.BeValidTransactionByTransactionId).When(x => !x?.TransactionId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidTransactionByTransactionId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleRepository.TransactionByTransactionId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>f4c3c09fa00716c65438ed59e456d345</Hash>
</Codenesium>*/