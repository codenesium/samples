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
        public abstract class AbstractApiSubscriptionRequestModelValidator : AbstractValidator<ApiSubscriptionRequestModel>
        {
                private string existingRecordId;

                private ISubscriptionRepository subscriptionRepository;

                public AbstractApiSubscriptionRequestModelValidator(ISubscriptionRepository subscriptionRepository)
                {
                        this.subscriptionRepository = subscriptionRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiSubscriptionRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

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
                        this.RuleFor(x => x).MustAsync(this.BeUniqueGetName).When(x => x?.Name != null).WithMessage("Violates unique constraint").WithName(nameof(ApiSubscriptionRequestModel.Name));
                        this.RuleFor(x => x.Name).Length(0, 200);
                }

                public virtual void TypeRules()
                {
                        this.RuleFor(x => x.Type).Length(0, 50);
                }

                private async Task<bool> BeUniqueGetName(ApiSubscriptionRequestModel model,  CancellationToken cancellationToken)
                {
                        Subscription record = await this.subscriptionRepository.GetName(model.Name);

                        if (record == null || (this.existingRecordId != default(string) && record.Id == this.existingRecordId))
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
    <Hash>2d5750d134763728f1ee88035e48141a</Hash>
</Codenesium>*/