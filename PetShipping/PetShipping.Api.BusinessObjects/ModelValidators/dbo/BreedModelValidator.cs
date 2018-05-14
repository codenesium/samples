using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiBreedModelValidator: AbstractApiBreedModelValidator, IApiBreedModelValidator
	{
		public ApiBreedModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiBreedModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>9106bbfac68c8f1af745eaeac2a74bd4</Hash>
</Codenesium>*/