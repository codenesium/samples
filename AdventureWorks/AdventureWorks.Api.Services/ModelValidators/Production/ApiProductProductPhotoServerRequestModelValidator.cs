using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class ApiProductProductPhotoServerRequestModelValidator : AbstractApiProductProductPhotoServerRequestModelValidator, IApiProductProductPhotoServerRequestModelValidator
	{
		public ApiProductProductPhotoServerRequestModelValidator(IProductProductPhotoRepository productProductPhotoRepository)
			: base(productProductPhotoRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiProductProductPhotoServerRequestModel model)
		{
			this.ModifiedDateRules();
			this.PrimaryRules();
			this.ProductPhotoIDRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiProductProductPhotoServerRequestModel model)
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
    <Hash>ff2dfb9ae74269344d475b87b23446a2</Hash>
</Codenesium>*/