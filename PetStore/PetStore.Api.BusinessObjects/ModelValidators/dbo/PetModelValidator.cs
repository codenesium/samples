using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class ApiPetModelValidator: AbstractApiPetModelValidator, IApiPetModelValidator
	{
		public ApiPetModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiPetModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiPetModel model)
		{
			this.AcquiredDateRules();
			this.BreedIdRules();
			this.DescriptionRules();
			this.PenIdRules();
			this.PriceRules();
			this.SpeciesIdRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>aa3ff7e5b77758c050157c98af55d875</Hash>
</Codenesium>*/