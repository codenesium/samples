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

                Task<List<ProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>732eff85ce1931736bb937c424ef7cee</Hash>
</Codenesium>*/