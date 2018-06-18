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

                Task<List<DeploymentEnvironment>> All(int limit = int.MaxValue, int offset = 0);

                Task<DeploymentEnvironment> GetName(string name);
                Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>917e8d0706d619a23e38e11206e11476</Hash>
</Codenesium>*/