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
			this.DescriptionRules();
			this.NameRules();
			this.StudioIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpaceModel model)
		{
			this.DescriptionRules();
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
    <Hash>29b1737117f9cedfb92f6872c3b0e4fe</Hash>
</Codenesium>*/