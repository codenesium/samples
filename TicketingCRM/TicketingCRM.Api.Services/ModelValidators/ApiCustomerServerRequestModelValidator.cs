using FluentValidation.Results;
using System;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public class ApiCustomerServerRequestModelValidator : AbstractApiCustomerServerRequestModelValidator, IApiCustomerServerRequestModelValidator
	{
		public ApiCustomerServerRequestModelValidator(ICustomerRepository customerRepository)
			: base(customerRepository)
		{
		}

		public async Task<ValidationResult> ValidateCreateAsync(ApiCustomerServerRequestModel model)
		{
			this.EmailRules();
			this.FirstNameRules();
			this.LastNameRules();
			this.PhoneRules();
			return await this.ValidateAsync(model);
		}

		public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiCustomerServerRequestModel model)
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
    <Hash>22cd4ee62ebf899e3f62c648355092d9</Hash>
</Codenesium>*/