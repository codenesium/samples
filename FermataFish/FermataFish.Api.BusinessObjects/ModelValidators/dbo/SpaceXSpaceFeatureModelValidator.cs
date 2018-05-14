using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class ApiSpaceXSpaceFeatureModelValidator: AbstractApiSpaceXSpaceFeatureModelValidator, IApiSpaceXSpaceFeatureModelValidator
	{
		public ApiSpaceXSpaceFeatureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpaceXSpaceFeatureModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpaceXSpaceFeatureModel model)
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
    <Hash>c3bbe22bbdcea21223a3df83691f70b2</Hash>
</Codenesium>*/