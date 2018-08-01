using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiSalesTerritoryHistoryRequestModelValidator : AbstractApiSalesTerritoryHistoryRequestModelValidator, IApiSalesTerritoryHistoryRequestModelValidator
	{
		public ApiSalesTerritoryHistoryRequestModelValidator(ISalesTerritoryHistoryRepository salesTerritoryHistoryRepository)
			: base(salesTerritoryHistoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSalesTerritoryHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSalesTerritoryHistoryRequestModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.RowguidRules();
			this.StartDateRules();
			this.TerritoryIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>a4dd491d674302809294b8f2c2c64cb1</Hash>
</Codenesium>*/