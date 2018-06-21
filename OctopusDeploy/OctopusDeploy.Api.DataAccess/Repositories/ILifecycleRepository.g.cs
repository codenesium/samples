using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>094d2fc21190aa74632abc3ac0f730bc</Hash>
</Codenesium>*/