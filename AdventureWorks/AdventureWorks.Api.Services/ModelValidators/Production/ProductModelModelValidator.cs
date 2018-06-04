using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductModelRequestModelValidator: AbstractApiProductModelRequestModelValidator, IApiProductModelRequestModelValidator
	{
		public ApiProductModelRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelRequestModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelRequestModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>013e88376094a41328fc5f8dff097461</Hash>
</Codenesium>*/