using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public class ApiSpaceXSpaceFeatureRequestModelValidator: AbstractApiSpaceXSpaceFeatureRequestModelValidator, IApiSpaceXSpaceFeatureRequestModelValidator
	{
		public ApiSpaceXSpaceFeatureRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>826da3f45bebef7398d5e2a60f5c21db</Hash>
</Codenesium>*/