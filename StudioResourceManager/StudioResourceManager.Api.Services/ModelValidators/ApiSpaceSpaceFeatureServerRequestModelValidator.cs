using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceSpaceFeatureServerRequestModelValidator : AbstractApiSpaceSpaceFeatureServerRequestModelValidator, IApiSpaceSpaceFeatureServerRequestModelValidator
	{
		public ApiSpaceSpaceFeatureServerRequestModelValidator(ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository)
			: base(spaceSpaceFeatureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceSpaceFeatureServerRequestModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureServerRequestModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6caf5860edcb1b49d9bd26fe0c79cd03</Hash>
</Codenesium>*/