using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>3716c68e8e3f9d58eb6e47a10eefde67</Hash>
</Codenesium>*/