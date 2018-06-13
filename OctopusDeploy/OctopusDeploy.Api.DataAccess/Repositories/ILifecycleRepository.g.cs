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

                Task<List<Lifecycle>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<Lifecycle> GetName(string name);
                Task<List<Lifecycle>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>61a05f6e53a9ac6bd8014731ec1fa907</Hash>
</Codenesium>*/