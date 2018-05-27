using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
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
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>938de7fabbf19aab9f5d8b30263b58b3</Hash>
</Codenesium>*/