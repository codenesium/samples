using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductCostHistoryModelValidator: AbstractApiProductCostHistoryModelValidator, IApiProductCostHistoryModelValidator
	{
		public ApiProductCostHistoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductCostHistoryModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCostHistoryModel model)
		{
			this.EndDateRules();
			this.ModifiedDateRules();
			this.StandardCostRules();
			this.StartDateRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>c9b5f0138ec039d7e1fd7e4fde396447</Hash>
</Codenesium>*/