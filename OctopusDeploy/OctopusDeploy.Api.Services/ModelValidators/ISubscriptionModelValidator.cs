using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>7c0f1ffb04e3d6774a0a15a04291b381</Hash>
</Codenesium>*/