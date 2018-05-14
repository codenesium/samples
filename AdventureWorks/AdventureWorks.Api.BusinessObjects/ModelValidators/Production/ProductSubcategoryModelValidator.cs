using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductSubcategoryModelValidator: AbstractApiProductSubcategoryModelValidator, IApiProductSubcategoryModelValidator
	{
		public ApiProductSubcategoryModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
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
    <Hash>228aecf8d3b9a5cd041b32a536a84cab</Hash>
</Codenesium>*/