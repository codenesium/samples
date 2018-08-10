using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public partial interface IDashboardConfigurationRepository
	{
		Task<DashboardConfiguration> Create(DashboardConfiguration item);

		Task Update(DashboardConfiguration item);

		Task Delete(string id);

		Task<DashboardConfiguration> Get(string id);

		Task<List<DashboardConfiguration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2406bbf48cc35362e1ad375fa8f086f7</Hash>
</Codenesium>*/