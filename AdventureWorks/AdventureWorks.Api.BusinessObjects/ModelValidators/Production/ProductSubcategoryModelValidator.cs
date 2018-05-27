using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductSubcategoryRequestModelValidator: AbstractApiProductSubcategoryRequestModelValidator, IApiProductSubcategoryRequestModelValidator
	{
		public ApiProductSubcategoryRequestModelValidator()
		{   }

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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b1520d6151b66ddc2f8170a90c0f6828</Hash>
</Codenesium>*/