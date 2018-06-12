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

                Task<List<Proxy>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Proxy> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>8893d032946c8cf138cb85e910383a75</Hash>
</Codenesium>*/