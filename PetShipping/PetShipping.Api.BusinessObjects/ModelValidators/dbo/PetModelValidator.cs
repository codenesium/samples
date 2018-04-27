using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class PetModelValidator: AbstractPetModelValidator, IPetModelValidator
	{
		public PetModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(PetModel model)
		{
			this.BreedIdRules();
			this.ClientIdRules();
			this.NameRules();
			this.WeightRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, PetModel model)
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
    <Hash>3ee0200a747b9f6fce32bab5156d0c4c</Hash>
</Codenesium>*/