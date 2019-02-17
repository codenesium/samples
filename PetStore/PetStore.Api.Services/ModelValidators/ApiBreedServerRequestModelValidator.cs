using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
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
    <Hash>0eab77e2eb1647254a9fb9f8eb702a2f</Hash>
</Codenesium>*/