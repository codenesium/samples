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

                Task<List<DeploymentHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<DeploymentHistory>> GetCreated(DateTime created);
        }
}

/*<Codenesium>
    <Hash>3f0e1c4fc4dc866185cb4eddb9c3dd06</Hash>
</Codenesium>*/