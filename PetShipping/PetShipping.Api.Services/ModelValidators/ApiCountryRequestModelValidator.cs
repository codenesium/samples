using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
	public class ApiCountryRequestModelValidator: AbstractApiCountryRequestModelValidator, IApiCountryRequestModelValidator
	{
		public ApiCountryRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiCountryRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCountryRequestModel model)
		{
			this.NameRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>35fc5b55fc22f36c973ffa8c3107279d</Hash>
</Codenesium>*/