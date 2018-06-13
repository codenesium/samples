using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentHistoryRepository
        {
                Task<DeploymentHistory> Create(DeploymentHistory item);

                Task Update(DeploymentHistory item);

                Task Delete(string deploymentId);

                Task<DeploymentHistory> Get(string deploymentId);

                Task<List<DeploymentHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<DeploymentHistory>> GetCreated(DateTimeOffset created);
        }
}

/*<Codenesium>
    <Hash>61ff4c98aaa1e6128a9478e8c6b14d2c</Hash>
</Codenesium>*/