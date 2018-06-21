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

                Task<Proxy> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>9292f7e28fb90ebc495ad8ee8cd3775e</Hash>
</Codenesium>*/