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

                Task<List<OctopusServerNode>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>97115c6d645ae21580207268942e682b</Hash>
</Codenesium>*/