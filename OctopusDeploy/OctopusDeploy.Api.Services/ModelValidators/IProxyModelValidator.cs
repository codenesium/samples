using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiProxyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiProxyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiProxyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>6a9e2300fb660723b1e6c451d182e7e3</Hash>
</Codenesium>*/