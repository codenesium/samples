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
    <Hash>39e2de33aa1c6f8050510470326a4948</Hash>
</Codenesium>*/