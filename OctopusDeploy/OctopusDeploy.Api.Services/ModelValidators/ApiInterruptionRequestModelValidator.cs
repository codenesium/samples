using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiInterruptionRequestModelValidator: AbstractApiInterruptionRequestModelValidator, IApiInterruptionRequestModelValidator
        {
                public ApiInterruptionRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiInterruptionRequestModel model)
                {
                        this.CreatedRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.ResponsibleTeamIdsRules();
                        this.StatusRules();
                        this.TaskIdRules();
                        this.TenantIdRules();
                        this.TitleRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiInterruptionRequestModel model)
                {
                        this.CreatedRules();
                        this.EnvironmentIdRules();
                        this.JSONRules();
                        this.ProjectIdRules();
                        this.RelatedDocumentIdsRules();
                        this.ResponsibleTeamIdsRules();
                        this.StatusRules();
                        this.TaskIdRules();
                        this.TenantIdRules();
                        this.TitleRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>3d3052501c8f1cf574f06acb4f33a554</Hash>
</Codenesium>*/