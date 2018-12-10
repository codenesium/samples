using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractApiVendorServerRequestModelValidator : AbstractValidator<ApiVendorServerRequestModel>
	{
		private int existingRecordId;

		protected IVendorRepository VendorRepository { get; private set; }

		public AbstractApiVendorServerRequestModelValidator(IVendorRepository vendorRepository)
		{
			this.VendorRepository = vendorRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiVendorServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AccountNumberRules()
		{
			this.RuleFor(x => x.AccountNumber).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByAccountNumber).When(x => (!x?.AccountNumber.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiVendorServerRequestModel.AccountNumber)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.AccountNumber).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ActiveFlagRules()
		{
		}

		public virtual void CreditRatingRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void PreferredVendorStatuRules()
		{
		}

		public virtual void PurchasingWebServiceURLRules()
		{
			this.RuleFor(x => x.PurchasingWebServiceURL).Length(0, 1024).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		protected async Task<bool> BeUniqueByAccountNumber(ApiVendorServerRequestModel model,  CancellationToken cancellationToken)
		{
			Vendor record = await this.VendorRepository.ByAccountNumber(model.AccountNumber);

			if (record == null || (this.existingRecordId != default(int) && record.BusinessEntityID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}

/*<Codenesium>
    <Hash>3896cb70f78cde1eeeba6f12968d8387</Hash>
</Codenesium>*/