using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IDeploymentProcessRepository
        {
                Task<DeploymentProcess> Create(DeploymentProcess item);

                Task Update(DeploymentProcess item);

                Task Delete(string id);

                Task<DeploymentProcess> Get(string id);

                Task<List<DeploymentProcess>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>5597124139409963476cd0338f300dc9</Hash>
</Codenesium>*/