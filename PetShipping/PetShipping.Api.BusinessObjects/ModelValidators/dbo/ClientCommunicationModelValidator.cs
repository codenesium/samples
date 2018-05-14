using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.BusinessObjects
{
	public class ApiClientCommunicationModelValidator: AbstractApiClientCommunicationModelValidator, IApiClientCommunicationModelValidator
	{
		public ApiClientCommunicationModelValidator()
		{   }

		public async Task<ValidationResult> ValidateCreateAsync(ApiClientCommunicationModel model)
		{
			this.ClientIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NotesRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiClientCommunicationModel model)
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
    <Hash>2c6682bbd91c808b2912544b842875bd</Hash>
</Codenesium>*/