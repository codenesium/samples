using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>82061de631e4a9ec505ec2234b18b99f</Hash>
</Codenesium>*/