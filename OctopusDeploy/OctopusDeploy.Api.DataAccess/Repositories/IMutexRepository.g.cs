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

                Task<List<Mutex>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>02c1093879913ba66248bca3a3923e66</Hash>
</Codenesium>*/