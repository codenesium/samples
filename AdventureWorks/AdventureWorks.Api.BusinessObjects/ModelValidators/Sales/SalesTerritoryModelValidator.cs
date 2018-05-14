using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesTerritoryModelValidator: AbstractApiSalesTerritoryModelValidator, IApiSalesTerritoryModelValidator
	{
		public ApiSalesTerritoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryModel model)
		{
			this.CostLastYearRules();
			this.CostYTDRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesYTDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryModel model)
		{
			this.CostLastYearRules();
			this.CostYTDRules();
			this.CountryRegionCodeRules();
			this.@GroupRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesYTDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>7cdb78f0c90bd2dbb4d4e2019dbd9814</Hash>
</Codenesium>*/