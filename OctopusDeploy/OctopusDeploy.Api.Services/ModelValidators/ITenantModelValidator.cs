using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiTenantRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiTenantRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiTenantRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>d12f47ffaa59ebab97644058953e6ee5</Hash>
</Codenesium>*/