using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductProductPhotoRequestModelValidator: AbstractApiProductProductPhotoRequestModelValidator, IApiProductProductPhotoRequestModelValidator
	{
		public ApiProductProductPhotoRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>14d3ee9cc2f37bac007b6fd4bfab050a</Hash>
</Codenesium>*/