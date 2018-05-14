using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductCategoryModelValidator: AbstractApiProductCategoryModelValidator, IApiProductCategoryModelValidator
	{
		public ApiProductCategoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryModel model)
		{
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
    <Hash>3b07ea475ce6b571817f0bf88c99fcaa</Hash>
</Codenesium>*/