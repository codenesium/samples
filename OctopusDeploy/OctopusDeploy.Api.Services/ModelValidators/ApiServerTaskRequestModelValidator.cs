using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiServerTaskRequestModelValidator: AbstractApiServerTaskRequestModelValidator, IApiServerTaskRequestModelValidator
        {
                public ApiServerTaskRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiServerTaskRequestModel model)
                {
                        this.CompletedTimeRules();
                        this.ConcurrencyTagRules();
                        this.DescriptionRules();
                        this.DurationSecondsRules();
                        this.EnvironmentIdRules();
                        this.ErrorMessageRules();
                        this.HasPendingInterruptionsRules();
                        this.HasWarningsOrErrorsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.QueueTimeRules();
                        this.ServerNodeIdRules();
                        this.StartTimeRules();
                        this.StateRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiServerTaskRequestModel model)
                {
                        this.CompletedTimeRules();
                        this.ConcurrencyTagRules();
                        this.DescriptionRules();
                        this.DurationSecondsRules();
                        this.EnvironmentIdRules();
                        this.ErrorMessageRules();
                        this.HasPendingInterruptionsRules();
                        this.HasWarningsOrErrorsRules();
                        this.JSONRules();
                        this.NameRules();
                        this.ProjectIdRules();
                        this.QueueTimeRules();
                        this.ServerNodeIdRules();
                        this.StartTimeRules();
                        this.StateRules();
                        this.TenantIdRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>506f280164cc2c073158d549d86c41ce</Hash>
</Codenesium>*/