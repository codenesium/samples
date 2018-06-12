using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.DataAccess
{
        public interface ILifecycleRepository
        {
                Task<Lifecycle> Create(Lifecycle item);

                Task Update(Lifecycle item);

                Task Delete(string id);

                Task<Lifecycle> Get(string id);

                Task<List<Lifecycle>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<Lifecycle> GetName(string name);
                Task<List<Lifecycle>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>e4c7b4e85ae3a4231435f1594132cb75</Hash>
</Codenesium>*/