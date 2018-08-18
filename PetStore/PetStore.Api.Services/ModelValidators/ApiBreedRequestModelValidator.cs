using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiBreedRequestModelValidator : AbstractApiBreedRequestModelValidator, IApiBreedRequestModelValidator
	{
		public ApiBreedRequestModelValidator(IBreedRepository breedRepository)
			: base(breedRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiBreedRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiBreedRequestModel model)
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
    <Hash>e47c9edfe38b5903219669a738533fcf</Hash>
</Codenesium>*/