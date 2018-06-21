using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiUserRoleRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiUserRoleRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRoleRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>9fb10e54abe1df4364acbcc268e9b268</Hash>
</Codenesium>*/