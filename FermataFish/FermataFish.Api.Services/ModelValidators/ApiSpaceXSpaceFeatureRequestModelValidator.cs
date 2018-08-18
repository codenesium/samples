using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using FluentValidation.Results;
using System;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public class ApiSpaceXSpaceFeatureRequestModelValidator : AbstractApiSpaceXSpaceFeatureRequestModelValidator, IApiSpaceXSpaceFeatureRequestModelValidator
	{
		public ApiSpaceXSpaceFeatureRequestModelValidator(ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository)
			: base(spaceXSpaceFeatureRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureRequestModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureRequestModel model)
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
    <Hash>ff8d061c95472412c1011ab81e8a647f</Hash>
</Codenesium>*/