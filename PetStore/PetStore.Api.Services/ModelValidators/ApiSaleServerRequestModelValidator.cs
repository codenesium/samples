using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
			this.AmountRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PaymentTypeIdRules();
			this.PetIdRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSaleServerRequestModel model)
		{
			this.AmountRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PaymentTypeIdRules();
			this.PetIdRules();
			this.PhoneRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}

		public virtual void AmountRules()
		{
		}

		public virtual void FirstNameRules()
		{
			this.RuleFor(x => x.FirstName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.FirstName).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void LastNameRules()
		{
			this.RuleFor(x => x.LastName).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.LastName).Length(0, 90).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PaymentTypeIdRules()
		{
			this.RuleFor(x => x.PaymentTypeId).MustAsync(this.BeValidPaymentTypeByPaymentTypeId).When(x => !x?.PaymentTypeId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PetIdRules()
		{
			this.RuleFor(x => x.PetId).MustAsync(this.BeValidPetByPetId).When(x => !x?.PetId.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		public virtual void PhoneRules()
		{
			this.RuleFor(x => x.Phone).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Phone).Length(0, 10).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeValidPaymentTypeByPaymentTypeId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleRepository.PaymentTypeByPaymentTypeId(id);

			return record != null;
		}

		protected async Task<bool> BeValidPetByPetId(int id,  CancellationToken cancellationToken)
		{
			var record = await this.SaleRepository.PetByPetId(id);

			return record != null;
		}
	}
}

/*<Codenesium>
    <Hash>542b453f792465ea0e50c2ff49509c66</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/