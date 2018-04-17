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
			this.SpaceIdRules();
			this.SpaceFeatureIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpaceXSpaceFeatureModel model)
		{
			this.SpaceIdRules();
			this.SpaceFeatureIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>dff91380ecbf2cb11b070d5746b4a420</Hash>
</Codenesium>*/