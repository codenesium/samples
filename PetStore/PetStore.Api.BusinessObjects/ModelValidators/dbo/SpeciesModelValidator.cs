using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

namespace PetStoreNS.Api.BusinessObjects
{
	public class SpeciesModelValidator: AbstractSpeciesModelValidator, ISpeciesModelValidator
	{
		public SpeciesModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(SpeciesModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, SpeciesModel model)
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
    <Hash>dce409dd923df10744e9d2ebab62376d</Hash>
</Codenesium>*/