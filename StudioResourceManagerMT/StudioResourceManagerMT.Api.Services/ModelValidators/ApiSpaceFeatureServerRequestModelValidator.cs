using FluentValidation.Results;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public class ApiSpaceFeatureServerRequestModelValidator : AbstractApiSpaceFeatureServerRequestModelValidator, IApiSpaceFeatureServerRequestModelValidator
	{
		public ApiSpaceFeatureServerRequestModelValidator(ISpaceFeatureRepository spaceFeatureRepository)
			: base(spaceFeatureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceFeatureServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceFeatureServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>60a275dd16241372274727ad8d3f5f0a</Hash>
</Codenesium>*/