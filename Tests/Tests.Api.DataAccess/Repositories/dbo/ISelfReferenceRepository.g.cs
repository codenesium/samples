using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestsNS.Api.DataAccess
{
        public interface ISelfReferenceRepository
        {
                Task<SelfReference> Create(SelfReference item);

                Task Update(SelfReference item);

                Task Delete(int id);

                Task<SelfReference> Get(int id);

                Task<List<SelfReference>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<SelfReference>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>43d18b10a6ba26e18c7547a4c226b3c0</Hash>
</Codenesium>*/