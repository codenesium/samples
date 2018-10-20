using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceFeatureRequestModelValidator : AbstractApiSpaceFeatureRequestModelValidator, IApiSpaceFeatureRequestModelValidator
	{
		public ApiSpaceFeatureRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
			: base(spaceFeatureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureRequestModel model)
		{
			this.NameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureRequestModel model)
		{
			this.NameRules();
			this.IsDeletedRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>b6395ccc031afa97755ab3c04a6ff827</Hash>
</Codenesium>*/