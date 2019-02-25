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
	public abstract class AbstractApiAddressServerRequestModelValidator : AbstractValidator<ApiAddressServerRequestModel>
	{
		private int existingRecordId;

		protected IAddressRepository AddressRepository { get; private set; }

		public AbstractApiAddressServerRequestModelValidator(IAddressRepository addressRepository)
		{
			this.AddressRepository = addressRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiAddressServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void AddressLine1Rules()
		{
			this.RuleFor(x => x.AddressLine1).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode).When(x => (!x?.AddressLine1.IsEmptyOrZeroOrNull() ?? false) || (!x?.AddressLine2.IsEmptyOrZeroOrNull() ?? false) || (!x?.City.IsEmptyOrZeroOrNull() ?? false) || (!x?.StateProvinceID.IsEmptyOrZeroOrNull() ?? false) || (!x?.PostalCode.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressServerRequestModel.AddressLine1)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.AddressLine1).Length(0, 60).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void AddressLine2Rules()
		{
			this.RuleFor(x => x.AddressLine2).Length(0, 60).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void CityRules()
		{
			this.RuleFor(x => x.City).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.City).Length(0, 30).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void PostalCodeRules()
		{
			this.RuleFor(x => x.PostalCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.PostalCode).Length(0, 15).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiAddressServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void StateProvinceIDRules()
		{
			this.RuleFor(x => x.StateProvinceID).MustAsync(this.BeValidStateProvinceByStateProvinceID).When(x => !x?.StateProvinceID.IsEmptyOrZeroOrNull() ?? false).WithMessage("Invalid reference").WithErrorCode(ValidationErrorCodes.ViolatesForeignKeyConstraintRule);
		}

		protected async Task<bool> BeValidStateProvinceByStateProvinceID(int id,  CancellationToken cancellationToken)
		{
			var record = await this.AddressRepository.StateProvinceByStateProvinceID(id);

			return record != null;
		}

		protected async Task<bool> BeUniqueByRowguid(ApiAddressServerRequestModel model,  CancellationToken cancellationToken)
		{
			Address record = await this.AddressRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.AddressID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByAddressLine1AddressLine2CityStateProvinceIDPostalCode(ApiAddressServerRequestModel model,  CancellationToken cancellationToken)
		{
			Address record = await this.AddressRepository.ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(model.AddressLine1, model.AddressLine2, model.City, model.StateProvinceID, model.PostalCode);

			if (record == null || (this.existingRecordId != default(int) && record.AddressID == this.existingRecordId))
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
    <Hash>36557967cd8f739cbd1d5ddcf938182e</Hash>
</Codenesium>*/