using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface IPipelineRepository
        {
                Task<Pipeline> Create(Pipeline item);

                Task Update(Pipeline item);

                Task Delete(int id);

                Task<Pipeline> Get(int id);

                Task<List<Pipeline>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>f4591d1c200f24ca15800f3252ab17ea</Hash>
</Codenesium>*/