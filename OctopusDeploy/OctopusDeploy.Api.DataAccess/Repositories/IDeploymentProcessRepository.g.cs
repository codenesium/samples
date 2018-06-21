using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>b5242a52c81c6c40619c5e69304c41a7</Hash>
</Codenesium>*/