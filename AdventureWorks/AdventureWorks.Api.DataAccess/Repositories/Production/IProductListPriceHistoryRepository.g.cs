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

                Task<List<ProductListPriceHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d82c8c77562f17c4cee2db545de64e5a</Hash>
</Codenesium>*/