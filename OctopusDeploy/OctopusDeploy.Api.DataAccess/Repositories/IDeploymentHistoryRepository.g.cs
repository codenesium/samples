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

                Task<List<DeploymentHistory>> ByCreated(DateTimeOffset created);
        }
}

/*<Codenesium>
    <Hash>8cc009b6048a58ccfb1840188ab7c70c</Hash>
</Codenesium>*/