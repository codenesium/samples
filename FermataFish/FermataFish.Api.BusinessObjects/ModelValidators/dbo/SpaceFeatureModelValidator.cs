using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class SpaceFeatureModelValidator: AbstractSpaceFeatureModelValidator, ISpaceFeatureModelValidator
	{
		public SpaceFeatureModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpaceFeatureModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpaceFeatureModel model)
		{
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>b6800584d07b91b76a7d4fe4ff541e9b</Hash>
</Codenesium>*/