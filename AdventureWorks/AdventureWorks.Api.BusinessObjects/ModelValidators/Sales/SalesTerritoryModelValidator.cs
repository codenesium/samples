using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class SalesTerritoryModelValidator: AbstractSalesTerritoryModelValidator, ISalesTerritoryModelValidator
	{
		public SalesTerritoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SalesTerritoryModel model)
		{
			this.NameRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.CostYTDRules();
			this.CostLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SalesTerritoryModel model)
		{
			this.NameRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.SalesYTDRules();
			this.SalesLastYearRules();
			this.CostYTDRules();
			this.CostLastYearRules();
			this.RowguidRules();
			this.ModifiedDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>a45a0b00ee632374e35f8bc71a1b725f</Hash>
</Codenesium>*/