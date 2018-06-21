using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>8263e3633c86b0f1ef3e69a88498eb55</Hash>
</Codenesium>*/