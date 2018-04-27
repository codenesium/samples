using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
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
    <Hash>5cf4055f3abe76bd3b93741448ca94c0</Hash>
</Codenesium>*/