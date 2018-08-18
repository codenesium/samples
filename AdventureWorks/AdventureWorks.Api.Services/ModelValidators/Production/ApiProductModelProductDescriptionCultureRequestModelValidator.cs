using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductModelProductDescriptionCultureRequestModelValidator : AbstractApiProductModelProductDescriptionCultureRequestModelValidator, IApiProductModelProductDescriptionCultureRequestModelValidator
	{
		public ApiProductModelProductDescriptionCultureRequestModelValidator(IProductModelProductDescriptionCultureRepository productModelProductDescriptionCultureRepository)
			: base(productModelProductDescriptionCultureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductModelProductDescriptionCultureRequestModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductModelProductDescriptionCultureRequestModel model)
		{
			this.CultureIDRules();
			this.ModifiedDateRules();
			this.ProductDescriptionIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>06c57e068271af1368f5993fc6c02faf</Hash>
</Codenesium>*/