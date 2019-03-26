using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductSubcategoryServerRequestModelValidator : AbstractApiProductSubcategoryServerRequestModelValidator, IApiProductSubcategoryServerRequestModelValidator
	{
		public ApiProductSubcategoryServerRequestModelValidator(IProductSubcategoryRepository productSubcategoryRepository)
			: base(productSubcategoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>ede353ab3632d86a6094c50c521da9dc</Hash>
</Codenesium>*/