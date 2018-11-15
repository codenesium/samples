using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductCategoryServerRequestModelValidator : AbstractApiProductCategoryServerRequestModelValidator, IApiProductCategoryServerRequestModelValidator
	{
		public ApiProductCategoryServerRequestModelValidator(IProductCategoryRepository productCategoryRepository)
			: base(productCategoryRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductCategoryServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.NameRules();
			this.RowguidRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductCategoryServerRequestModel model)
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
    <Hash>0d53263fcb867c6e4bd5f4aa7ff3c91a</Hash>
</Codenesium>*/