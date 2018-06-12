using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>619fcf19195273b6a1c4d7036d966635</Hash>
</Codenesium>*/