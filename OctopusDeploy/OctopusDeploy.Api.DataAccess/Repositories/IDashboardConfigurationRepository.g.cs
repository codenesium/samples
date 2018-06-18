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

                Task<List<DashboardConfiguration>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9a112935b97b0a409f1b6861243ff373</Hash>
</Codenesium>*/