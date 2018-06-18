using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiTicketStatusRequestModelValidator: AbstractValidator<ApiTicketStatusRequestModel>
        {
                private int existingRecordId;

                ITicketStatusRepository ticketStatusRepository;

                public AbstractApiTicketStatusRequestModelValidator(ITicketStatusRepository ticketStatusRepository)
                {
                        this.ticketStatusRepository = ticketStatusRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiTicketStatusRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>c0a51e372d5eda281ba4fcce70bee409</Hash>
</Codenesium>*/