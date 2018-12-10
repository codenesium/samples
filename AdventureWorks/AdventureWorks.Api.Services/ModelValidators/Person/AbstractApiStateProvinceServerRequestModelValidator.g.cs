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
	public abstract class AbstractApiStateProvinceServerRequestModelValidator : AbstractValidator<ApiStateProvinceServerRequestModel>
	{
		private int existingRecordId;

		protected IStateProvinceRepository StateProvinceRepository { get; private set; }

		public AbstractApiStateProvinceServerRequestModelValidator(IStateProvinceRepository stateProvinceRepository)
		{
			this.StateProvinceRepository = stateProvinceRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiStateProvinceServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void IsOnlyStateProvinceFlagRules()
		{
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void StateProvinceCodeRules()
		{
			this.RuleFor(x => x.StateProvinceCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByStateProvinceCodeCountryRegionCode).When(x => (!x?.StateProvinceCode.IsEmptyOrZeroOrNull() ?? false) || (!x?.StateProvinceCode.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiStateProvinceServerRequestModel.StateProvinceCode)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.StateProvinceCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void TerritoryIDRules()
		{
		}

		protected async Task<bool> BeUniqueByName(ApiStateProvinceServerRequestModel model,  CancellationToken cancellationToken)
		{
			StateProvince record = await this.StateProvinceRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.StateProvinceID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiStateProvinceServerRequestModel model,  CancellationToken cancellationToken)
		{
			StateProvince record = await this.StateProvinceRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.StateProvinceID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByStateProvinceCodeCountryRegionCode(ApiStateProvinceServerRequestModel model,  CancellationToken cancellationToken)
		{
			StateProvince record = await this.StateProvinceRepository.ByStateProvinceCodeCountryRegionCode(model.StateProvinceCode, model.CountryRegionCode);

			if (record == null || (this.existingRecordId != default(int) && record.StateProvinceID == this.existingRecordId))
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
    <Hash>42f33711376fc8c57a46c6b72fff14a4</Hash>
</Codenesium>*/