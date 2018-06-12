using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMachineRequestModelValidator: AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
        {
                public ApiMachineRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiMachineRequestModel model)
                {
                        this.CommunicationStyleRules();
                        this.EnvironmentIdsRules();
                        this.FingerprintRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.MachinePolicyIdRules();
                        this.NameRules();
                        this.RelatedDocumentIdsRules();
                        this.RolesRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiMachineRequestModel model)
                {
                        this.CommunicationStyleRules();
                        this.EnvironmentIdsRules();
                        this.FingerprintRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.MachinePolicyIdRules();
                        this.NameRules();
                        this.RelatedDocumentIdsRules();
                        this.RolesRules();
                        this.TenantIdsRules();
                        this.TenantTagsRules();
                        this.ThumbprintRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>5066572e72a2f3f3ad97fa69ca916515</Hash>
</Codenesium>*/