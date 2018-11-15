using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiClientServerRequestModelValidator : AbstractApiClientServerRequestModelValidator, IApiClientServerRequestModelValidator
	{
		public ApiClientServerRequestModelValidator(IClientRepository clientRepository)
			: base(clientRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NoteRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NoteRules();
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
    <Hash>94f8199e85edd7636193a04897d9007c</Hash>
</Codenesium>*/