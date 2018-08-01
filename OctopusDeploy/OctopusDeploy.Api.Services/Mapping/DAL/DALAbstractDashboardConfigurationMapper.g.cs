using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
	public abstract class DALAbstractDashboardConfigurationMapper
	{
		public virtual DashboardConfiguration MapBOToEF(
			BODashboardConfiguration bo)
		{
			DashboardConfiguration efDashboardConfiguration = new DashboardConfiguration();
			efDashboardConfiguration.SetProperties(
				bo.Id,
				bo.IncludedEnvironmentIds,
				bo.IncludedProjectIds,
				bo.IncludedTenantIds,
				bo.IncludedTenantTags,
				bo.JSON);
			return efDashboardConfiguration;
		}

		public virtual BODashboardConfiguration MapEFToBO(
			DashboardConfiguration ef)
		{
			var bo = new BODashboardConfiguration();

			bo.SetProperties(
				ef.Id,
				ef.IncludedEnvironmentIds,
				ef.IncludedProjectIds,
				ef.IncludedTenantIds,
				ef.IncludedTenantTags,
				ef.JSON);
			return bo;
		}

		public virtual List<BODashboardConfiguration> MapEFToBO(
			List<DashboardConfiguration> records)
		{
			List<BODashboardConfiguration> response = new List<BODashboardConfiguration>();

			records.ForEach(r =>
			{
				response.Add(this.MapEFToBO(r));
			});

			return response;
		}
	}
}

/*<Codenesium>
    <Hash>c2a381ad6b62c8215db5c40d9744baf2</Hash>
</Codenesium>*/