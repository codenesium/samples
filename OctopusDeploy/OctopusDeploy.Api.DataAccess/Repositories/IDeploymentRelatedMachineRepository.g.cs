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

                Task<List<DeploymentRelatedMachine>> ByDeploymentId(string deploymentId);

                Task<List<DeploymentRelatedMachine>> ByMachineId(string machineId);

                Task<Deployment> GetDeployment(string deploymentId);
        }
}

/*<Codenesium>
    <Hash>cefd5da71ebcd28ac18d57ca665a6dee</Hash>
</Codenesium>*/