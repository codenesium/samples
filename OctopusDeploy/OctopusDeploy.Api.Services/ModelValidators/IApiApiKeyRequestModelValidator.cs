using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiApiKeyRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiApiKeyRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiApiKeyRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>7e74208ca5d43ce8fcd71771d9c771d2</Hash>
</Codenesium>*/