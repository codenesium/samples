using FluentValidation.Results;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class ApiCustomerCommunicationServerRequestModelValidator : AbstractApiCustomerCommunicationServerRequestModelValidator, IApiCustomerCommunicationServerRequestModelValidator
	{
		public ApiCustomerCommunicationServerRequestModelValidator(ICustomerCommunicationRepository customerCommunicationRepository)
			: base(customerCommunicationRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerCommunicationServerRequestModel model)
		{
			this.CustomerIdRules();
			this.DateCreatedRules();
			this.EmployeeIdRules();
			this.NoteRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerCommunicationServerRequestModel model)
		{
			this.CustomerIdRules();
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
    <Hash>552ceb045a3142eb8a392248ea00da88</Hash>
</Codenesium>*/