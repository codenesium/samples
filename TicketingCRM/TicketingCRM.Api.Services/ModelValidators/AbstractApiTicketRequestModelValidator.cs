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
        public abstract class AbstractApiTicketRequestModelValidator: AbstractValidator<ApiTicketRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiTicketRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiTicketRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ITicketStatusRepository TicketStatusRepository { get; set; }

                public virtual void PublicIdRules()
                {
                        this.RuleFor(x => x.PublicId).NotNull();
                        this.RuleFor(x => x.PublicId).Length(0, 8);
                }

                public virtual void TicketStatusIdRules()
                {
                        this.RuleFor(x => x.TicketStatusId).MustAsync(this.BeValidTicketStatus).When(x => x ?.TicketStatusId != null).WithMessage("Invalid reference");
                }

                private async Task<bool> BeValidTicketStatus(int id,  CancellationToken cancellationToken)
                {
                        var record = await this.TicketStatusRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>eead6ca2343621cf55a62056b7a36574</Hash>
</Codenesium>*/