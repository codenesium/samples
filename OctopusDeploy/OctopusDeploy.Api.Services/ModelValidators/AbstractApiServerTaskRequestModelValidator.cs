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
        public abstract class AbstractApiServerTaskRequestModelValidator: AbstractValidator<ApiServerTaskRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiServerTaskRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiServerTaskRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void CompletedTimeRules()
                {
                }

                public virtual void ConcurrencyTagRules()
                {
                        this.RuleFor(x => x.ConcurrencyTag).Length(0, 100);
                }

                public virtual void DescriptionRules()
                {
                        this.RuleFor(x => x.Description).NotNull();
                }

                public virtual void DurationSecondsRules()
                {
                        this.RuleFor(x => x.DurationSeconds).NotNull();
                }

                public virtual void EnvironmentIdRules()
                {
                        this.RuleFor(x => x.EnvironmentId).Length(0, 50);
                }

                public virtual void ErrorMessageRules()
                {
                }

                public virtual void HasPendingInterruptionsRules()
                {
                        this.RuleFor(x => x.HasPendingInterruptions).NotNull();
                }

                public virtual void HasWarningsOrErrorsRules()
                {
                        this.RuleFor(x => x.HasWarningsOrErrors).NotNull();
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x.Name).Length(0, 50);
                }

                public virtual void ProjectIdRules()
                {
                        this.RuleFor(x => x.ProjectId).Length(0, 50);
                }

                public virtual void QueueTimeRules()
                {
                        this.RuleFor(x => x.QueueTime).NotNull();
                }

                public virtual void ServerNodeIdRules()
                {
                        this.RuleFor(x => x.ServerNodeId).Length(0, 250);
                }

                public virtual void StartTimeRules()
                {
                }

                public virtual void StateRules()
                {
                        this.RuleFor(x => x.State).NotNull();
                        this.RuleFor(x => x.State).Length(0, 50);
                }

                public virtual void TenantIdRules()
                {
                        this.RuleFor(x => x.TenantId).Length(0, 50);
                }
        }
}

/*<Codenesium>
    <Hash>1354ae1ce5c7d37f26fa3fe118171f15</Hash>
</Codenesium>*/