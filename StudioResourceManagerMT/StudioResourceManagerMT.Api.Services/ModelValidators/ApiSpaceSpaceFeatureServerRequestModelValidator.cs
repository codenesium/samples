using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureServerRequestModel model)
		{
			this.SpaceFeatureIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>568b1336d613c606a4959caf9ff64a06</Hash>
</Codenesium>*/