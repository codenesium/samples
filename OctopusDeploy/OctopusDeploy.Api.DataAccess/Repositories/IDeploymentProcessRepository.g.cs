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

                Task<List<DeploymentProcess>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>39f819a2c2a1886ec09bc33a4a9dd21b</Hash>
</Codenesium>*/