using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface IMutexRepository
        {
                Task<Mutex> Create(Mutex item);

                Task Update(Mutex item);

                Task Delete(string id);

                Task<Mutex> Get(string id);

                Task<List<Mutex>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>7ee7d704a89e9b090fb2e4811b48d5c7</Hash>
</Codenesium>*/