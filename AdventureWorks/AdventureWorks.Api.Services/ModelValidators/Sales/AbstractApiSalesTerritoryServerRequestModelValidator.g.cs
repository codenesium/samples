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
	public abstract class AbstractApiSalesTerritoryServerRequestModelValidator : AbstractValidator<ApiSalesTerritoryServerRequestModel>
	{
		private int existingRecordId;

		protected ISalesTerritoryRepository SalesTerritoryRepository { get; private set; }

		public AbstractApiSalesTerritoryServerRequestModelValidator(ISalesTerritoryRepository salesTerritoryRepository)
		{
			this.SalesTerritoryRepository = salesTerritoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryServerRequestModel model, int id)
		{
			this.existingRecordId = id;
			return await this.ValidateAsync(model);
		}

		public virtual void CostLastYearRules()
		{
		}

		public virtual void CostYTDRules()
		{
		}

		public virtual void CountryRegionCodeRules()
		{
			this.RuleFor(x => x.CountryRegionCode).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void @GroupRules()
		{
			this.RuleFor(x => x.@Group).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x.@Group).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull().WithErrorCode(ValidationErrorCodes.ViolatesShouldNotBeNullRule);
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => (!x?.Name.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryServerRequestModel.Name)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
			this.RuleFor(x => x.Name).Length(0, 50).WithErrorCode(ValidationErrorCodes.ViolatesLengthRule);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => (!x?.Rowguid.IsEmptyOrZeroOrNull() ?? false)).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryServerRequestModel.Rowguid)).WithErrorCode(ValidationErrorCodes.ViolatesUniqueConstraintRule);
		}

		public virtual void SalesLastYearRules()
		{
		}

		public virtual void SalesYTDRules()
		{
		}

		protected async Task<bool> BeUniqueByName(ApiSalesTerritoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTerritory record = await this.SalesTerritoryRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.TerritoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		protected async Task<bool> BeUniqueByRowguid(ApiSalesTerritoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTerritory record = await this.SalesTerritoryRepository.ByRowguid(model.Rowguid);

			if (record == null || (this.existingRecordId != default(int) && record.TerritoryID == this.existingRecordId))
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
    <Hash>e8d640041b0838f13795a92134770009</Hash>
</Codenesium>*/