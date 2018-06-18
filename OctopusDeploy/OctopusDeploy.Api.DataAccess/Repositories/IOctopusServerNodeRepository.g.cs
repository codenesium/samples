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

                Task<List<OctopusServerNode>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>9a0f240d32a69ffe493b79495bdc5745</Hash>
</Codenesium>*/