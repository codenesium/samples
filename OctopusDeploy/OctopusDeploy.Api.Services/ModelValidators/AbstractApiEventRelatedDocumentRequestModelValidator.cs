using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiEventRelatedDocumentRequestModelValidator: AbstractValidator<ApiEventRelatedDocumentRequestModel>
        {
                private int existingRecordId;

                public ValidationResult Validate(ApiEventRelatedDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiEventRelatedDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public IEventRepository EventRepository { get; set; }

                public virtual void EventIdRules()
                {
                        this.RuleFor(x => x.EventId).NotNull();
                        this.RuleFor(x => x.EventId).MustAsync(this.BeValidEvent).When(x => x ?.EventId != null).WithMessage("Invalid reference");
                        this.RuleFor(x => x.EventId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdRules()
                {
                        this.RuleFor(x => x.RelatedDocumentId).NotNull();
                        this.RuleFor(x => x.RelatedDocumentId).Length(0, 250);
                }

                private async Task<bool> BeValidEvent(string id,  CancellationToken cancellationToken)
                {
                        var record = await this.EventRepository.Get(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>396c15e21acd1c22b81c26222bf7456a</Hash>
</Codenesium>*/