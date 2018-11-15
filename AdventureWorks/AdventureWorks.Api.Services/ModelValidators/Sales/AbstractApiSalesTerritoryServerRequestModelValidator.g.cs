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

		private ISalesTerritoryRepository salesTerritoryRepository;

		public AbstractApiSalesTerritoryServerRequestModelValidator(ISalesTerritoryRepository salesTerritoryRepository)
		{
			this.salesTerritoryRepository = salesTerritoryRepository;
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
			this.RuleFor(x => x.CountryRegionCode).NotNull();
			this.RuleFor(x => x.CountryRegionCode).Length(0, 3);
		}

		public virtual void @GroupRules()
		{
			this.RuleFor(x => x.@Group).NotNull();
			this.RuleFor(x => x.@Group).Length(0, 50);
		}

		public virtual void ModifiedDateRules()
		{
		}

		public virtual void NameRules()
		{
			this.RuleFor(x => x.Name).NotNull();
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => !x?.Name.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryServerRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
			this.RuleFor(x => x).MustAsync(this.BeUniqueByRowguid).When(x => !x?.Rowguid.IsEmptyOrZeroOrNull() ?? false).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryServerRequestModel.Rowguid));
		}

		public virtual void SalesLastYearRules()
		{
		}

		public virtual void SalesYTDRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiSalesTerritoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTerritory record = await this.salesTerritoryRepository.ByName(model.Name);

			if (record == null || (this.existingRecordId != default(int) && record.TerritoryID == this.existingRecordId))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private async Task<bool> BeUniqueByRowguid(ApiSalesTerritoryServerRequestModel model,  CancellationToken cancellationToken)
		{
			SalesTerritory record = await this.salesTerritoryRepository.ByRowguid(model.Rowguid);

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
    <Hash>9effce9b1bb5c981bf5c24d7f412cc9a</Hash>
</Codenesium>*/