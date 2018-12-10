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
    <Hash>f19368da4b0221d0746a51490b9ff94a</Hash>
</Codenesium>*/