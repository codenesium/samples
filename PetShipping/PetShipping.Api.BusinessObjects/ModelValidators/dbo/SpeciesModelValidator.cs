using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiSpeciesModelValidator: AbstractApiSpeciesModelValidator, IApiSpeciesModelValidator
	{
		public ApiSpeciesModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpeciesModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesModel model)
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
    <Hash>85331376ce2ece5f68e26b01c1283c4c</Hash>
</Codenesium>*/