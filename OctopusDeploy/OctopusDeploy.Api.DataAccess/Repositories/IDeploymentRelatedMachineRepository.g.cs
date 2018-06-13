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

                Task<List<DeploymentRelatedMachine>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<DeploymentRelatedMachine>> GetDeploymentId(string deploymentId);
                Task<List<DeploymentRelatedMachine>> GetMachineId(string machineId);
        }
}

/*<Codenesium>
    <Hash>b4d52fbdf901810381c3e3c67db08e89</Hash>
</Codenesium>*/