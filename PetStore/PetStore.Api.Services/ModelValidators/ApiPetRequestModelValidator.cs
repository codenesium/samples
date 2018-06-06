using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.Services
{
	public class ApiPetRequestModelValidator: AbstractApiPetRequestModelValidator, IApiPetRequestModelValidator
	{
		public ApiPetRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetRequestModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetRequestModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4382b0e5c0d7011cd484a49e9e2ecaf4</Hash>
</Codenesium>*/