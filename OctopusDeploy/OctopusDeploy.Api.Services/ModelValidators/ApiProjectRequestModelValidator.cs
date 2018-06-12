using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiProjectRequestModelValidator: AbstractApiProjectRequestModelValidator, IApiProjectRequestModelValidator
        {
                public ApiProjectRequestModelValidator()
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiProjectRequestModel model)
                {
                        this.AutoCreateReleaseRules();
                        this.DataVersionRules();
                        this.DeploymentProcessIdRules();
                        this.DiscreteChannelReleaseRules();
                        this.IncludedLibraryVariableSetIdsRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.LifecycleIdRules();
                        this.NameRules();
                        this.ProjectGroupIdRules();
                        this.SlugRules();
                        this.VariableSetIdRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiProjectRequestModel model)
                {
                        this.AutoCreateReleaseRules();
                        this.DataVersionRules();
                        this.DeploymentProcessIdRules();
                        this.DiscreteChannelReleaseRules();
                        this.IncludedLibraryVariableSetIdsRules();
                        this.IsDisabledRules();
                        this.JSONRules();
                        this.LifecycleIdRules();
                        this.NameRules();
                        this.ProjectGroupIdRules();
                        this.SlugRules();
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
    <Hash>7dfcfb2ac84c371ab4b74cd38f21b0a0</Hash>
</Codenesium>*/