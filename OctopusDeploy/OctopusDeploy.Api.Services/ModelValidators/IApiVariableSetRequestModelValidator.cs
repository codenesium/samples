using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

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
    <Hash>18ae84ae3fa002e746439f426eab11c0</Hash>
</Codenesium>*/