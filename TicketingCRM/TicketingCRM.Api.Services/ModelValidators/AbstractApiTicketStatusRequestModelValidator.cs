using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractApiTicketStatusRequestModelValidator : AbstractValidator<ApiTicketStatusRequestModel>
        {
                private int existingRecordId;

                private ITicketStatusRepository ticketStatusRepository;

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
                        this.RuleFor(x => x.Name).Length(0, 128);
                }
        }
}

/*<Codenesium>
    <Hash>3b8ed6baddfd989417f66ce0883d3f56</Hash>
</Codenesium>*/