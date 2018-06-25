using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProxyRepository
        {
                Task<Proxy> Create(Proxy item);

                Task Update(Proxy item);

                Task Delete(string id);

                Task<Proxy> Get(string id);

                Task<List<Proxy>> All(int limit = int.MaxValue, int offset = 0);

                Task<Proxy> ByName(string name);
        }
}

/*<Codenesium>
    <Hash>370b18dea30b213d39bcdaa35dd9a831</Hash>
</Codenesium>*/