using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiSpeciesRequestModelValidator: AbstractApiSpeciesRequestModelValidator, IApiSpeciesRequestModelValidator
	{
		public ApiSpeciesRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiSpeciesRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiSpeciesRequestModel model)
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
    <Hash>ec2e578e360e49088e9a4c3b8d20867c</Hash>
</Codenesium>*/