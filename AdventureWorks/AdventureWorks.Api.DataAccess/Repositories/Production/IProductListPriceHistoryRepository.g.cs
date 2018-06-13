using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductListPriceHistoryRepository
        {
                Task<ProductListPriceHistory> Create(ProductListPriceHistory item);

                Task Update(ProductListPriceHistory item);

                Task Delete(int productID);

                Task<ProductListPriceHistory> Get(int productID);

                Task<List<ProductListPriceHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>42389f0b376b3c84a885784fd6695695</Hash>
</Codenesium>*/