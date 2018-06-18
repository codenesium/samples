using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiSubscriptionRequestModelValidator: AbstractApiSubscriptionRequestModelValidator, IApiSubscriptionRequestModelValidator
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
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>c69788b941767bf9c3de605295f96c49</Hash>
</Codenesium>*/