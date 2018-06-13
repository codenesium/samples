using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentEnvironmentRepository
        {
                Task<DeploymentEnvironment> Create(DeploymentEnvironment item);

                Task Update(DeploymentEnvironment item);

                Task Delete(string id);

                Task<DeploymentEnvironment> Get(string id);

                Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<DeploymentEnvironment> GetName(string name);
                Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>b48a5e04d8591ac6c1e4ed35fe64bd4f</Hash>
</Codenesium>*/