using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IOctopusServerNodeRepository
        {
                Task<OctopusServerNode> Create(OctopusServerNode item);

                Task Update(OctopusServerNode item);

                Task Delete(string id);

                Task<OctopusServerNode> Get(string id);

                Task<List<OctopusServerNode>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6bb05d27e8b355a07214866dcbc2cc98</Hash>
</Codenesium>*/