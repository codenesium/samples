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

                Task<List<DeploymentProcess>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>d36bd5551effd80ad957563cf4ea198b</Hash>
</Codenesium>*/