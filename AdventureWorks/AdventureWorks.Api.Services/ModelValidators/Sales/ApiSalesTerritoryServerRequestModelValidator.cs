using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesTerritoryServerRequestModelValidator : AbstractApiSalesTerritoryServerRequestModelValidator, IApiSalesTerritoryServerRequestModelValidator
	{
		public ApiSalesTerritoryServerRequestModelValidator(ISalesTerritoryRepository salesTerritoryRepository)
			: base(salesTerritoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryServerRequestModel model)
		{
			this.CostLastYearRules();
			this.CostYTDRules();
			this.CountryRegionCodeRules();
			this.ReservedGroupRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesYTDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryServerRequestModel model)
		{
			this.CostLastYearRules();
			this.CostYTDRules();
			this.CountryRegionCodeRules();
			this.ReservedGroupRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			this.SalesLastYearRules();
			this.SalesYTDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>eb2161db5fb676c2bfc9a481271d2365</Hash>
</Codenesium>*/