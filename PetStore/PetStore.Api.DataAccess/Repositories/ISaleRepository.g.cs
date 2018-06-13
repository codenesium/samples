using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PetStoreNS.Api.DataAccess
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
    <Hash>2f1986bae13415cc6e2e912abc667276</Hash>
</Codenesium>*/