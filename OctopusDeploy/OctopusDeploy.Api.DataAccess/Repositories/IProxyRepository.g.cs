using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IProxyRepository
        {
                Task<Proxy> Create(Proxy item);

                Task Update(Proxy item);

                Task Delete(string id);

                Task<Proxy> Get(string id);

                Task<List<Proxy>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Proxy> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>7d9f9666093dcb22dedf9540d01ba771</Hash>
</Codenesium>*/