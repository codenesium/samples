using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetShippingNS.Api.DataAccess
{
        public interface ISaleRepository
        {
                Task<Sale> Create(Sale item);

                Task Update(Sale item);

                Task Delete(int id);

                Task<Sale> Get(int id);

                Task<List<Sale>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>af2054a659c141cce4df8caacd28a5ee</Hash>
</Codenesium>*/