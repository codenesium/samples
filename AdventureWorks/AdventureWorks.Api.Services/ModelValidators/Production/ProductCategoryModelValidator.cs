using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductCategoryRequestModelValidator: AbstractApiProductCategoryRequestModelValidator, IApiProductCategoryRequestModelValidator
	{
		public ApiProductCategoryRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>6b658348520476b2fbc202308e141798</Hash>
</Codenesium>*/