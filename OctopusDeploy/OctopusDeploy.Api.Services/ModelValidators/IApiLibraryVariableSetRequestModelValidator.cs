using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public interface IApiLibraryVariableSetRequestModelValidator
        {
                Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model);

                Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model);

                Task<ValidationResult> ValidateDeleteAsync(string id);
        }
}

/*<Codenesium>
    <Hash>65bf1fb1f4ad29236dd16fce4714a9c4</Hash>
</Codenesium>*/