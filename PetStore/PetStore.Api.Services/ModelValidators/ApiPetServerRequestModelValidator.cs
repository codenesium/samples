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
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetServerRequestModel model)
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
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>d5c4fd917d9f581982fce455e7afc918</Hash>
</Codenesium>*/