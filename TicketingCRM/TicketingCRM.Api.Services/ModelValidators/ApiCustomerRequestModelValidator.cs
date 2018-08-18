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
    <Hash>1d8d1c00c5fcb79d1d4d07dec46e5459</Hash>
</Codenesium>*/