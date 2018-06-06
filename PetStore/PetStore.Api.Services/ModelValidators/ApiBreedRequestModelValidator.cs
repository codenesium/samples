using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class ApiBreedRequestModelValidator: AbstractApiBreedRequestModelValidator, IApiBreedRequestModelValidator
	{
		public ApiBreedRequestModelValidator()
		{   }

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
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>1d36180b608830e5eef607747d300536</Hash>
</Codenesium>*/