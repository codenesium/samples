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
        public abstract class AbstractApiSubscriptionRequestModelValidator: AbstractValidator<ApiSubscriptionRequestModel>
        {
                private string existingRecordId;

                public ValidationResult Validate(ApiSubscriptionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return this.Validate(model);
                }

                public async Task<ValidationResult> ValidateAsync(ApiSubscriptionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public ISubscriptionRepository SubscriptionRepository { get; set; }
                public virtual void IsDisabledRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }

                public virtual void NameRules()
                {
                        this.RuleFor(x => x.Name).NotNull();
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x ?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSubscriptionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void TypeRules()
                {
                        this.RuleFor(x => x.Type).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiSubscriptionRequestModel model,  CancellationToken cancellationToken)
                {
                        Subscription record = await this.SubscriptionRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default (string) && record.Id == this.existingRecordId))
                        {
                                return true;
                        }
                        else
                        {
                                return false;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>a24e1e174b8edbebd8cda2d380da9b9e</Hash>
</Codenesium>*/