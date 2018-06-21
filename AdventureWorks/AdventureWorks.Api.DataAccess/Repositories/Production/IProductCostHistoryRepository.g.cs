using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductCostHistoryRepository
        {
                Task<ProductCostHistory> Create(ProductCostHistory item);

                Task Update(ProductCostHistory item);

                Task Delete(int productID);

                Task<ProductCostHistory> Get(int productID);

                Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>63d03a1cfcb37ea466ba5a04b9c8b85c</Hash>
</Codenesium>*/