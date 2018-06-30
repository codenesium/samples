using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMachinePolicyRequestModelValidator : AbstractApiMachinePolicyRequestModelValidator, IApiMachinePolicyRequestModelValidator
        {
                public ApiMachinePolicyRequestModelValidator(IMachinePolicyRepository machinePolicyRepository)
                        : base(machinePolicyRepository)
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>81d2a6d22bfd1fe890edc3fdeeeffc00</Hash>
</Codenesium>*/