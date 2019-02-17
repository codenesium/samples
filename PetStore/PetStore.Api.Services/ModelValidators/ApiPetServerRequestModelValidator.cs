using FluentValidation.Results;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetStoreNS.Api.Services
{
	public class ApiPetServerRequestModelValidator : AbstractApiPetServerRequestModelValidator, IApiPetServerRequestModelValidator
	{
		public ApiPetServerRequestModelValidator(IPetRepository petRepository)
			: base(petRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetServerRequestModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>cc7f73204212551e5af2dedc4d70981d</Hash>
</Codenesium>*/