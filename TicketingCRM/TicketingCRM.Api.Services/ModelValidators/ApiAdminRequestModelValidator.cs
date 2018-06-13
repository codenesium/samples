using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiAdminRequestModelValidator: AbstractApiAdminRequestModelValidator, IApiAdminRequestModelValidator
        {
                public ApiAdminRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiAdminRequestModel model)
                {
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PasswordRules();
                        this.PhoneRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiAdminRequestModel model)
                {
                        this.EmailRules();
                        this.FirstNameRules();
                        this.LastNameRules();
                        this.PasswordRules();
                        this.PhoneRules();
                        this.UsernameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>7f1bf0ece932fa97d553169f55946136</Hash>
</Codenesium>*/