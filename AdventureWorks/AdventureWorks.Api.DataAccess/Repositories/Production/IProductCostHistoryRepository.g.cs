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

                Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>dd4e0a663db47a54b6d2486f6def2137</Hash>
</Codenesium>*/