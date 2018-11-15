using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiBreedServerRequestModelValidator : AbstractApiBreedServerRequestModelValidator, IApiBreedServerRequestModelValidator
	{
		public ApiBreedServerRequestModelValidator(IBreedRepository breedRepository)
			: base(breedRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBreedServerRequestModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedServerRequestModel model)
		{
			this.NameRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>20834fac45a7d3b9a4d59ed702e3ca54</Hash>
</Codenesium>*/