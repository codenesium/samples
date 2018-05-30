using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiAirlineRequestModelValidator: AbstractApiAirlineRequestModelValidator, IApiAirlineRequestModelValidator
	{
		public ApiAirlineRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirlineRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineRequestModel model)
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
    <Hash>04a1e5b0660aaa8f364e49ec91839754</Hash>
</Codenesium>*/