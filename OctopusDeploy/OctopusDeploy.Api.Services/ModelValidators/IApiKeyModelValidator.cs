using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>60bdb330ee83b4e052f76045bed78196</Hash>
</Codenesium>*/