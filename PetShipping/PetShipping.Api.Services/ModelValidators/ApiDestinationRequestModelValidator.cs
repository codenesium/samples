using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiDestinationRequestModelValidator: AbstractApiDestinationRequestModelValidator, IApiDestinationRequestModelValidator
	{
		public ApiDestinationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiDestinationRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiDestinationRequestModel model)
		{
			this.CountryIdRules();
			this.NameRules();
			this.OrderRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>679f118edc8115c046e571505fb40269</Hash>
</Codenesium>*/