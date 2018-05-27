using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>39558f1916d5301033abe4678abe912a</Hash>
</Codenesium>*/