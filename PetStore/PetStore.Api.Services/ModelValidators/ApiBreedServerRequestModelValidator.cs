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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedServerRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>f82606a4a19484ac539ea8df1b71c1d0</Hash>
</Codenesium>*/