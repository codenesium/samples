using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiAirlineModelValidator: AbstractApiAirlineModelValidator, IApiAirlineModelValidator
	{
		public ApiAirlineModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiAirlineModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAirlineModel model)
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
    <Hash>9b44cdb24f8506b68e8631cb4ff10458</Hash>
</Codenesium>*/