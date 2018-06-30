using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiSubscriptionRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiSubscriptionRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiSubscriptionRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>e0695f2cae94d2ef535c3b43185a5f19</Hash>
</Codenesium>*/