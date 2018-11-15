using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiHandlerServerRequestModelValidator : AbstractApiHandlerServerRequestModelValidator, IApiHandlerServerRequestModelValidator
	{
		public ApiHandlerServerRequestModelValidator(IHandlerRepository handlerRepository)
			: base(handlerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiHandlerServerRequestModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiHandlerServerRequestModel model)
		{
			this.CountryIdRules();
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>6f5b9ba47d7242b67868df846ccade83</Hash>
</Codenesium>*/