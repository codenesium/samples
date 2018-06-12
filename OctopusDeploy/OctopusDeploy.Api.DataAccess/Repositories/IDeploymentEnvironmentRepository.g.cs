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

                Task<List<DeploymentEnvironment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<DeploymentEnvironment> GetName(string name);
                Task<List<DeploymentEnvironment>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>914fe7feab6da1d59cf401b109686d7d</Hash>
</Codenesium>*/