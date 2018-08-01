using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiCustomerRequestModelValidator : AbstractApiCustomerRequestModelValidator, IApiCustomerRequestModelValidator
	{
		public ApiCustomerRequestModelValidator(ICustomerRepository customerRepository)
			: base(customerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerRequestModel model)
		{
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
    <Hash>c7cf97a8dd8244971b4502113b671988</Hash>
</Codenesium>*/