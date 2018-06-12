using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiVariableSetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiVariableSetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiVariableSetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>97ac10ced2aa7faad665984b6c039563</Hash>
</Codenesium>*/