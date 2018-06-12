using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiReleaseRequestModelValidator: AbstractApiReleaseRequestModelValidator, IApiReleaseRequestModelValidator
        {
                public ApiReleaseRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiReleaseRequestModel model)
                {
                        this.AssembledRules();
                        this.ChannelIdRules();
                        this.JSONRules();
                        this.ProjectDeploymentProcessSnapshotIdRules();
                        this.ProjectIdRules();
                        this.ProjectVariableSetSnapshotIdRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiReleaseRequestModel model)
                {
                        this.AssembledRules();
                        this.ChannelIdRules();
                        this.JSONRules();
                        this.ProjectDeploymentProcessSnapshotIdRules();
                        this.ProjectIdRules();
                        this.ProjectVariableSetSnapshotIdRules();
                        this.VersionRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>a96f91d72f4952c4a248c6045eb63e96</Hash>
</Codenesium>*/