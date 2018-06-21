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
    <Hash>870c10f11c6f3fd185a0dc2ed47f1cc2</Hash>
</Codenesium>*/