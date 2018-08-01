using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
	public interface IDashboardConfigurationRepository
	{
		Task<DashboardConfiguration> Create(DashboardConfiguration item);

		Task Update(DashboardConfiguration item);

		Task Delete(string id);

		Task<DashboardConfiguration> Get(string id);

		Task<List<DashboardConfiguration>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>716bd92c91c7f0ffec450f5a40ce88bb</Hash>
</Codenesium>*/