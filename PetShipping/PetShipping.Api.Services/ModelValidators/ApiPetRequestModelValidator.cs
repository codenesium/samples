using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPetRequestModelValidator : AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
	{
		public ApiPetRequestModelValidator(IPetRepository petRepository)
			: base(petRepository)
		{
		}

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
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>4918bee44347f49a876e958706f35492</Hash>
</Codenesium>*/