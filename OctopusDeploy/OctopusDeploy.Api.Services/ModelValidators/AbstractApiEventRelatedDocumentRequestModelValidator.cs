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

                IEventRelatedDocumentRepository eventRelatedDocumentRepository;

                public AbstractApiEventRelatedDocumentRequestModelValidator(IEventRelatedDocumentRepository eventRelatedDocumentRepository)
                {
                        this.eventRelatedDocumentRepository = eventRelatedDocumentRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEventRelatedDocumentRequestModel model, int id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        var record = await this.eventRelatedDocumentRepository.GetEvent(id);

                        return record != null;
                }
        }
}

/*<Codenesium>
    <Hash>0dea1a1cedcc61f0dc5a01cf4164829c</Hash>
</Codenesium>*/