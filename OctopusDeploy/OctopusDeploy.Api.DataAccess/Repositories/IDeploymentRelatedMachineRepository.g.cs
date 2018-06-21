using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentRelatedMachineRepository
        {
                Task<DeploymentRelatedMachine> Create(DeploymentRelatedMachine item);

                Task Update(DeploymentRelatedMachine item);

                Task Delete(int id);

                Task<DeploymentRelatedMachine> Get(int id);

                Task<List<DeploymentRelatedMachine>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<DeploymentRelatedMachine>> GetDeploymentId(string deploymentId);

                Task<List<DeploymentRelatedMachine>> GetMachineId(string machineId);

                Task<Deployment> GetDeployment(string deploymentId);
        }
}

/*<Codenesium>
    <Hash>00ce7ad0fd5de5393c7bdbee199c5e61</Hash>
</Codenesium>*/