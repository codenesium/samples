using Codenesium.DataConversionExtensions;
using FluentValidation;
using FluentValidation.Results;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Services
{
        public abstract class AbstractApiDashboardConfigurationRequestModelValidator : AbstractValidator<ApiDashboardConfigurationRequestModel>
        {
                private string existingRecordId;

                private IDashboardConfigurationRepository dashboardConfigurationRepository;

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
                }

                public virtual void IncludedProjectIdsRules()
                {
                }

                public virtual void IncludedTenantIdsRules()
                {
                }

                public virtual void IncludedTenantTagsRules()
                {
                }

                public virtual void JSONRules()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bbdf0ee43b6e996f378ed70e017de64c</Hash>
</Codenesium>*/