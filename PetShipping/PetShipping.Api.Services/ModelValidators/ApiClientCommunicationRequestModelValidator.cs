using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiClientCommunicationRequestModelValidator : AbstractApiClientCommunicationRequestModelValidator, IApiClientCommunicationRequestModelValidator
	{
		public ApiClientCommunicationRequestModelValidator(IClientCommunicationRepository clientCommunicationRepository)
			: base(clientCommunicationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NoteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model)
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
    <Hash>47e6cb932ac38127a3132785a8ffed2a</Hash>
</Codenesium>*/