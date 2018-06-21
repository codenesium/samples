using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiUserRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiUserRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiUserRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>3cab4d03027744895cef686be494ea32</Hash>
</Codenesium>*/