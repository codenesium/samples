using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public class SpaceModelValidator: AbstractSpaceModelValidator, ISpaceModelValidator
	{
		public SpaceModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpaceModel model)
		{
			this.NameRules();
			this.DescriptionRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpaceModel model)
		{
			this.NameRules();
			this.DescriptionRules();
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
    <Hash>d476e072d62cb1ad8f9ba3f7fcac2ad5</Hash>
</Codenesium>*/