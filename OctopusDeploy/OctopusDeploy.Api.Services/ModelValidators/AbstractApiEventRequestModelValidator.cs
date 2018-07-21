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
        public abstract class AbstractApiEventRequestModelValidator : AbstractValidator<ApiEventRequestModel>
        {
                private string existingRecordId;

                private IEventRepository eventRepository;

                public AbstractApiEventRequestModelValidator(IEventRepository eventRepository)
                {
                        this.eventRepository = eventRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiEventRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void AutoIdRules()
                {
                }

                public virtual void CategoryRules()
                {
                        this.RuleFor(x => x.Category).Length(0, 50);
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                }

                public virtual void MessageRules()
                {
                }

                public virtual void OccurredRules()
                {
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void RelatedDocumentIdsRules()
                {
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void UserIdRules()
                {
                        this.RuleFor(x => x.UserId).Length(0, 50);
                }

                public virtual void UsernameRules()
                {
                        this.RuleFor(x => x.Username).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>7a9ecce0ac652324055619e9cf85f2cc</Hash>
</Codenesium>*/