using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTicketRequestModelValidator: AbstractApiTicketRequestModelValidator, IApiTicketRequestModelValidator
        {
                public ApiTicketRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiTicketRequestModel model)
                {
                        this.PublicIdRules();
                        this.TicketStatusIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(int id, ApiTicketRequestModel model)
                {
                        this.PublicIdRules();
                        this.TicketStatusIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(int id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>fcc9e284fa559c461aa66dceb5461592</Hash>
</Codenesium>*/