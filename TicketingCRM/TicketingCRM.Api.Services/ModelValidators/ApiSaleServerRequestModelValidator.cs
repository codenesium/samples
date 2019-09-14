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
	public class ApiSaleServerRequestModelValidator : AbstractValidator<ApiSaleServerRequestModel>, IApiSaleServerRequestModelValidator
	{
		private int existingRecordId;

		protected ISaleRepository SaleRepository { get; private set; }

		public ApiSaleServerRequestModelValidator(ISaleRepository saleRepository)
		{
			this.SaleRepository = saleRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSaleServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSaleServerRequestModel model)
		{
			this.IpAddressRules();
			this.NotesRules();
			this.SaleDateRules();
			this.TransactionIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.IpAddressRules();
			this.NotesRules();
			this.SaleDateRules();
			this.TransactionIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void IpAddressRules()
		{
			this.RuleFor(x => x.IpAddress).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.IpAddress).Length(0, 128).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void NotesRules()
		{
			this.RuleFor(x => x.Notes).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Notes).Length(0, 2147483647).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
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
    <Hash>02e91e464692496cc781e591e0f24d9b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/