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

                Task<List<DashboardConfiguration>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>84cb61790f27299f3b0f9a90cd127005</Hash>
</Codenesium>*/