using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ClientCommunicationModelValidator: AbstractClientCommunicationModelValidator, IClientCommunicationModelValidator
	{
		public ClientCommunicationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ClientCommunicationModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ClientCommunicationModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return new ValidationResult();
		}
	}
}

/*<Codenesium>
    <Hash>4c927160c888fb3311fd23ed900a391b</Hash>
</Codenesium>*/