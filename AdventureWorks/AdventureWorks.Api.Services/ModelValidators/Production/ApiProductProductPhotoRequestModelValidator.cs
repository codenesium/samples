using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductProductPhotoRequestModelValidator : AbstractApiProductProductPhotoRequestModelValidator, IApiProductProductPhotoRequestModelValidator
	{
		public ApiProductProductPhotoRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
			: base(productProductPhotoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoRequestModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoRequestModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>969fba1beb8f1b250c3e04ff8ac10c5e</Hash>
</Codenesium>*/