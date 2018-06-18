using Codenesium.DataConversionExtensions.AspNetCore;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Threading;
using System.Threading.Tasks;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiDashboardConfigurationRequestModelValidator: AbstractValidator<ApiDashboardConfigurationRequestModel>
        {
                private string existingRecordId;

                IDashboardConfigurationRepository dashboardConfigurationRepository;

                public AbstractApiDashboardConfigurationRequestModelValidator(IDashboardConfigurationRepository dashboardConfigurationRepository)
                {
                        this.dashboardConfigurationRepository = dashboardConfigurationRepository;
                }

                public async Task<ValidationResult> ValidateAsync(ApiDashboardConfigurationRequestModel model, string id)
                {
                        this.existingRecordId = id;
                        return await this.ValidateAsync(model);
                }

                public virtual void IncludedEnvironmentIdsRules()
                {
                        this.RuleFor(x => x.IncludedEnvironmentIds).NotNull();
                }

                public virtual void IncludedProjectIdsRules()
                {
                        this.RuleFor(x => x.IncludedProjectIds).NotNull();
                }

                public virtual void IncludedTenantIdsRules()
                {
                }

                public virtual void IncludedTenantTagsRules()
                {
                }

                public virtual void JSONRules()
                {
                        this.RuleFor(x => x.JSON).NotNull();
                }
        }
}

/*<Codenesium>
    <Hash>2a9e9d9ef403498aec770b2a28e28eb4</Hash>
</Codenesium>*/