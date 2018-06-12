using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProjectTriggerRequestModelValidator: AbstractApiProjectTriggerRequestModelValidator, IApiProjectTriggerRequestModelValidator
        {
                public ApiProjectTriggerRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProjectTriggerRequestModel model)
                {
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.TriggerTypeRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectTriggerRequestModel model)
                {
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.TriggerTypeRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>956d7f6a2cad91c09ed12dc612519795</Hash>
</Codenesium>*/