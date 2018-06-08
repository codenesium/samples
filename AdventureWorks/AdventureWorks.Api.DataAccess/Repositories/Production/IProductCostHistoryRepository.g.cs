using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductCostHistoryRepository
        {
                Task<ProductCostHistory> Create(ProductCostHistory item);

                Task Update(ProductCostHistory item);

                Task Delete(int productID);

                Task<ProductCostHistory> Get(int productID);

                Task<List<ProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4c1722c8434cfde6a4e72c473600f9d0</Hash>
</Codenesium>*/