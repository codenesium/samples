using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTicketStatusRequestModelValidator: AbstractApiTicketStatusRequestModelValidator, IApiTicketStatusRequestModelValidator
        {
                public ApiTicketStatusRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTicketStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketStatusRequestModel model)
                {
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>81d2e6e60ca9d04b4f86e09d09099a5e</Hash>
</Codenesium>*/