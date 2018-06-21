using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>48202eda511a8827342aec4fbac9a1ad</Hash>
</Codenesium>*/