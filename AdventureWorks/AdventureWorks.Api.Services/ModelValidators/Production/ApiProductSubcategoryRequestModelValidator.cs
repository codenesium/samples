using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductSubcategoryRequestModelValidator : AbstractApiProductSubcategoryRequestModelValidator, IApiProductSubcategoryRequestModelValidator
	{
		public ApiProductSubcategoryRequestModelValidator(IProductSubcategoryRepository productSubcategoryRepository)
			: base(productSubcategoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductSubcategoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.ProductCategoryIDRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductSubcategoryRequestModel model)
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
    <Hash>5d66e02c0c2e694ab21da061f309fc04</Hash>
</Codenesium>*/