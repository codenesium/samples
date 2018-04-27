using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class SpaceXSpaceFeatureModelValidator: AbstractSpaceXSpaceFeatureModelValidator, ISpaceXSpaceFeatureModelValidator
	{
		public SpaceXSpaceFeatureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpaceXSpaceFeatureModel model)
		{
			this.SpaceFeatureIdRules();
			this.SpaceIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpaceXSpaceFeatureModel model)
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
    <Hash>cacd0ebea9a169f8a1f550ddf0f35c93</Hash>
</Codenesium>*/