using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiSalesTerritoryRequestModelValidator: AbstractApiSalesTerritoryRequestModelValidator, IApiSalesTerritoryRequestModelValidator
	{
		public ApiSalesTerritoryRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryRequestModel model)
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

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryRequestModel model)
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
    <Hash>9aabe43b4cab604a120f0471e0622d13</Hash>
</Codenesium>*/