using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>b085e10e7394cae9cf7ce2f20a630c87</Hash>
</Codenesium>*/