using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public class ApiOctopusServerNodeRequestModelValidator : AbstractApiOctopusServerNodeRequestModelValidator, IApiOctopusServerNodeRequestModelValidator
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
                        return await Task.FromResult<ValidationResult>(new ValidationResult());
                }
        }
}

/*<Codenesium>
    <Hash>9f244135231bd62e43bd2d730860a91b</Hash>
</Codenesium>*/