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

                Task<List<Pipeline>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>a02c25ef89cebed4e4da19c2f4395481</Hash>
</Codenesium>*/