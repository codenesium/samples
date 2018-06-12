using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentRelatedMachineRepository
        {
                Task<DeploymentRelatedMachine> Create(DeploymentRelatedMachine item);

                Task Update(DeploymentRelatedMachine item);

                Task Delete(int id);

                Task<DeploymentRelatedMachine> Get(int id);

                Task<List<DeploymentRelatedMachine>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<List<DeploymentRelatedMachine>> GetDeploymentId(string deploymentId);
                Task<List<DeploymentRelatedMachine>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>30c8536d73ba6dbc40dc13b8f6f94bf2</Hash>
</Codenesium>*/