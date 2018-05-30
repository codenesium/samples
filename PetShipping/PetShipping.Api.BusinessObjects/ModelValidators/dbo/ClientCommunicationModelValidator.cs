using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiClientCommunicationRequestModelValidator: AbstractApiClientCommunicationRequestModelValidator, IApiClientCommunicationRequestModelValidator
	{
		public ApiClientCommunicationRequestModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationRequestModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationRequestModel model)
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
    <Hash>cc2086bc3bb1588705806c7e4613072b</Hash>
</Codenesium>*/