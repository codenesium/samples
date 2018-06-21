using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiConfigurationRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiConfigurationRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiConfigurationRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>492f3e8da35e143d08e1e406cec57d2e</Hash>
</Codenesium>*/