using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentEnvironmentRepository
        {
                Task<DeploymentEnvironment> Create(DeploymentEnvironment item);

                Task Update(DeploymentEnvironment item);

                Task Delete(string id);

                Task<DeploymentEnvironment> Get(string id);

                Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset = 0);

                Task<DeploymentEnvironment> GetName(string name);

                Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>825ba3873b2b8d571b26becc6b4638fa</Hash>
</Codenesium>*/