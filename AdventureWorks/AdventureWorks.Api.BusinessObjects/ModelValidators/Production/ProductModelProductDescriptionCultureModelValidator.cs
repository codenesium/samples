using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class ApiProductModelProductDescriptionCultureModelValidator: AbstractApiProductModelProductDescriptionCultureModelValidator, IApiProductModelProductDescriptionCultureModelValidator
	{
		public ApiProductModelProductDescriptionCultureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>89f780fd01d7f6d941808bfe908f6c04</Hash>
</Codenesium>*/