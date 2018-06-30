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
    <Hash>15608e3a4e9d59af6455de289ba0e059</Hash>
</Codenesium>*/