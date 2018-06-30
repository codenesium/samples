using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiEventRelatedDocumentRequestModelValidator : AbstractValidator<ApiEventRelatedDocumentRequestModel>
        {
                private int existingRecordId;

                private IEventRelatedDocumentRepository eventRelatedDocumentRepository;

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
                        this.RuleFor(x => x.EventId).MustAsync(this.BeValidEvent).When(x => x?.EventId != null).WithMessage("Invalid reference");
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
    <Hash>edab51994d43027ed05ec4461aa5de97</Hash>
</Codenesium>*/