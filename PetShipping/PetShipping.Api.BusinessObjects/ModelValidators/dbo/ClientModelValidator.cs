using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ClientModelValidator: AbstractClientModelValidator, IClientModelValidator
	{
		public ClientModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ClientModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NotesRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ClientModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.NotesRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>8bc2a92a65d1e44ce4c39426a7b84800</Hash>
</Codenesium>*/