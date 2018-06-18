using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiMachineRequestModelValidator: AbstractApiMachineRequestModelValidator, IApiMachineRequestModelValidator
        {
                public ApiMachineRequestModelValidator(IMachineRepository machineRepository)
                        : base(machineRepository)
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
    <Hash>7b378726b4e8531bc5a95559e6d3a73c</Hash>
</Codenesium>*/