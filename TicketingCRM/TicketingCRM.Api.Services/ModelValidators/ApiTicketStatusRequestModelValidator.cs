using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class ApiTicketStatusRequestModelValidator: AbstractApiTicketStatusRequestModelValidator, IApiTicketStatusRequestModelValidator
        {
                public ApiTicketStatusRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
                        : base(ticketStatusRepository)
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
    <Hash>d7fa79fc5537e26f6bf4c75fd05e8124</Hash>
</Codenesium>*/