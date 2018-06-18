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

                Task<List<Lifecycle>> All(int limit = int.MaxValue, int offset = 0);

                Task<Lifecycle> GetName(string name);
                Task<List<Lifecycle>> GetDataVersion(byte[] dataVersion);
        }
}

/*<Codenesium>
    <Hash>06cd936b448ce4ca3f0e1cd73184f8af</Hash>
</Codenesium>*/