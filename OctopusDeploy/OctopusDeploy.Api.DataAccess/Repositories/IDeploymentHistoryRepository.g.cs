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

                Task<List<DeploymentHistory>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<DeploymentHistory>> GetCreated(DateTimeOffset created);
        }
}

/*<Codenesium>
    <Hash>da6d5dd95f227ecf856dae58d7fca5a3</Hash>
</Codenesium>*/