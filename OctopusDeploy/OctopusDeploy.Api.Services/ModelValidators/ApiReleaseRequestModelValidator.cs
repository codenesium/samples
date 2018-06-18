using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiReleaseRequestModelValidator: AbstractApiReleaseRequestModelValidator, IApiReleaseRequestModelValidator
        {
                public ApiReleaseRequestModelValidator(IReleaseRepository releaseRepository)
                        : base(releaseRepository)
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
    <Hash>815eb11fa16808f28d38cfbe42d14780</Hash>
</Codenesium>*/