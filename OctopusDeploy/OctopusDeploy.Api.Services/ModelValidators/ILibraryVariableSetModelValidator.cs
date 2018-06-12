using System;
using System.Threading.Tasks;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;

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
    <Hash>f280cbd0819cde4d83c834813075de23</Hash>
</Codenesium>*/