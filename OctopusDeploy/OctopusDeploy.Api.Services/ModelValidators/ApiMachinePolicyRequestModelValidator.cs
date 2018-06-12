using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMachinePolicyRequestModelValidator: AbstractApiMachinePolicyRequestModelValidator, IApiMachinePolicyRequestModelValidator
        {
                public ApiMachinePolicyRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiMachinePolicyRequestModel model)
                {
                        this.IsDefaultRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachinePolicyRequestModel model)
                {
                        this.IsDefaultRules();
                        this.JSONRules();
                        this.NameRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a5a4884fc8fdb91fc3b38576b3f09e1c</Hash>
</Codenesium>*/