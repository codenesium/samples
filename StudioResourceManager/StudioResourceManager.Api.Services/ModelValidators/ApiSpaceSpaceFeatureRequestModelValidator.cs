using FluentValidation.Results;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public class ApiSpaceSpaceFeatureRequestModelValidator : AbstractApiSpaceSpaceFeatureRequestModelValidator, IApiSpaceSpaceFeatureRequestModelValidator
	{
		public ApiSpaceSpaceFeatureRequestModelValidator(ISpaceSpaceFeatureRepository spaceSpaceFeatureRepository)
			: base(spaceSpaceFeatureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceSpaceFeatureRequestModel model)
		{
			this.SpaceFeatureIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceSpaceFeatureRequestModel model)
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
    <Hash>7247f4540d2b7cdb7889d85eee7a6792</Hash>
</Codenesium>*/