using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTenantVariableRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTenantVariableRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantVariableRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>9ef8ff69cfb17c77610498dea1d38557</Hash>
</Codenesium>*/