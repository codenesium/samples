using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiSubscriptionRequestModelValidator : AbstractApiSubscriptionRequestModelValidator, IApiSubscriptionRequestModelValidator
        {
                public ApiSubscriptionRequestModelValidator(ISubscriptionRepository subscriptionRepository)
                        : base(subscriptionRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionRequestModel model)
                {
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.NameRules();
                        this.TypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiSubscriptionRequestModel model)
                {
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.NameRules();
                        this.TypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>f29dc5abce973e492912951803944936</Hash>
</Codenesium>*/