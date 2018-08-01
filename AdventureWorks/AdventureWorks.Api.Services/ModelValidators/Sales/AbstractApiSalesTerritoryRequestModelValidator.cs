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
	public abstract class AbstractApiSalesTerritoryRequestModelValidator : AbstractValidator<ApiSalesTerritoryRequestModel>
	{
		private int existingRecordId;

		private ISalesTerritoryRepository salesTerritoryRepository;

		public AbstractApiSalesTerritoryRequestModelValidator(ISalesTerritoryRepository salesTerritoryRepository)
		{
			this.salesTerritoryRepository = salesTerritoryRepository;
		}

		public async Task<ValidationResult> ValidateAsync(ApiSalesTerritoryRequestModel model, int id)
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
			this.RuleFor(x => x).MustAsync(this.BeUniqueByName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSalesTerritoryRequestModel.Name));
			this.RuleFor(x => x.Name).Length(0, 50);
		}

		public virtual void RowguidRules()
		{
		}

		public virtual void SalesLastYearRules()
		{
		}

		public virtual void SalesYTDRules()
		{
		}

		private async Task<bool> BeUniqueByName(ApiSalesTerritoryRequestModel model,  CancellationToken cancellationToken)
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
	}
}

/*<Codenesium>
    <Hash>1e631285890f5530c1ffe9dd2f366a80</Hash>
</Codenesium>*/