using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiPetServerRequestModelValidator : AbstractApiPetServerRequestModelValidator, IApiPetServerRequestModelValidator
	{
		public ApiPetServerRequestModelValidator(IPetRepository petRepository)
			: base(petRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetServerRequestModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model)
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
    <Hash>be401dcd2547c51b5355a8d3a6a6be1f</Hash>
</Codenesium>*/