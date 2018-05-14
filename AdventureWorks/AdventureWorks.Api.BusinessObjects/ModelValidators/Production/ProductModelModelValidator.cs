using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductModelModelValidator: AbstractApiProductModelModelValidator, IApiProductModelModelValidator
	{
		public ApiProductModelModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelModel model)
		{
			this.CatalogDescriptionRules();
			this.InstructionsRules();
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelModel model)
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
    <Hash>4a7b589bfb608ec9b80b44fdb46875bf</Hash>
</Codenesium>*/