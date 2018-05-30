using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiPetRequestModelValidator: AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
	{
		public ApiPetRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>60f6b8320dc64258d20eb3ba00a560d2</Hash>
</Codenesium>*/