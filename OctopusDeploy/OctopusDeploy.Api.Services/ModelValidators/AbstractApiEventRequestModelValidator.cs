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
                        this.RuleFor(x => x.Category).NotNull();
                        this.RuleFor(x => x.Category).Length(0, 50);
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void MessageRules()
                {
                        this.RuleFor(x => x.Message).NotNull();
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
                        this.RuleFor(x => x.RelatedDocumentIds).NotNull();
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }

                public virtual void UserIdRules()
                {
                        this.RuleFor(x => x.UserId).NotNull();
                        this.RuleFor(x => x.UserId).Length(0, 50);
                }

                public virtual void UsernameRules()
                {
                        this.RuleFor(x => x.Username).NotNull();
                        this.RuleFor(x => x.Username).Length(0, 200);
                }
        }
}

/*<Codenesium>
    <Hash>8d37dcbaa56dc8dd6537e650c549fac5</Hash>
</Codenesium>*/