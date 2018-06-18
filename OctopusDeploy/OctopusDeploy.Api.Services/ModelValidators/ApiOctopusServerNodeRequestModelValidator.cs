using System;
using FluentValidation.Results;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ApiOctopusServerNodeRequestModelValidator: AbstractApiOctopusServerNodeRequestModelValidator, IApiOctopusServerNodeRequestModelValidator
        {
                public ApiOctopusServerNodeRequestModelValidator(IOctopusServerNodeRepository octopusServerNodeRepository)
                        : base(octopusServerNodeRepository)
                {
                }

                public async Task<ValidationResult> ValidateCreateAsync(ApiOctopusServerNodeRequestModel model)
                {
                        this.IsInMaintenanceModeRules();
                        this.JSONRules();
                        this.LastSeenRules();
                        this.MaxConcurrentTasksRules();
                        this.NameRules();
                        this.RankRules();
                        return await this.ValidateAsync(model);
                }

                public async Task<ValidationResult> ValidateUpdateAsync(string id, ApiOctopusServerNodeRequestModel model)
                {
                        this.IsInMaintenanceModeRules();
                        this.JSONRules();
                        this.LastSeenRules();
                        this.MaxConcurrentTasksRules();
                        this.NameRules();
                        this.RankRules();
                        return await this.ValidateAsync(model, id);
                }

                public async Task<ValidationResult> ValidateDeleteAsync(string id)
                {
                        return new ValidationResult();
                }
        }
}

/*<Codenesium>
    <Hash>20b3620a5592300dbc99845b1e22b187</Hash>
</Codenesium>*/