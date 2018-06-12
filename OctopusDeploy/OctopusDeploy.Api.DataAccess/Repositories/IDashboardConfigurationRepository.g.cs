using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDashboardConfigurationRepository
        {
                Task<DashboardConfiguration> Create(DashboardConfiguration item);

                Task Update(DashboardConfiguration item);

                Task Delete(string id);

                Task<DashboardConfiguration> Get(string id);

                Task<List<DashboardConfiguration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8b1c733067131c9507d51c3470e4a053</Hash>
</Codenesium>*/