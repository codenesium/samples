using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiLibraryVariableSetRequestModelValidator: AbstractApiLibraryVariableSetRequestModelValidator, IApiLibraryVariableSetRequestModelValidator
        {
                public ApiLibraryVariableSetRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiLibraryVariableSetRequestModel model)
                {
                        this.ContentTypeRules();
                        this.JSONRules();
                        this.NameRules();
                        this.VariableSetIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiLibraryVariableSetRequestModel model)
                {
                        this.ContentTypeRules();
                        this.JSONRules();
                        this.NameRules();
                        this.VariableSetIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>e799dbc04b740723c74c431d57dd8c6d</Hash>
</Codenesium>*/