using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class BreedModelValidator: AbstractBreedModelValidator, IBreedModelValidator
	{
		public BreedModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(BreedModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, BreedModel model)
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
    <Hash>784e13e5863c2383a4cf46f247532ac2</Hash>
</Codenesium>*/