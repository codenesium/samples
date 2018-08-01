using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductCategoryRequestModelValidator : AbstractApiProductCategoryRequestModelValidator, IApiProductCategoryRequestModelValidator
	{
		public ApiProductCategoryRequestModelValidator(IProductCategoryRepository productCategoryRepository)
			: base(productCategoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
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
    <Hash>bf0c8e59136bd3fcff97a09c146d33e4</Hash>
</Codenesium>*/