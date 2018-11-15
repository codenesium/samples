using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiClientCommunicationServerRequestModelValidator : AbstractApiClientCommunicationServerRequestModelValidator, IApiClientCommunicationServerRequestModelValidator
	{
		public ApiClientCommunicationServerRequestModelValidator(IClientCommunicationRepository clientCommunicationRepository)
			: base(clientCommunicationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationServerRequestModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NoteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationServerRequestModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NoteRules();
			return await this.ValidateAsync(model, id);
		}

		public async Task<ValidationResult> ValidateDeleteAsync(int id)
		{
			return await Task.FromResult<ValidationResult>(new ValidationResult());
		}
	}
}

/*<Codenesium>
    <Hash>7b9538861318cdedba9c5be3230a23a7</Hash>
</Codenesium>*/