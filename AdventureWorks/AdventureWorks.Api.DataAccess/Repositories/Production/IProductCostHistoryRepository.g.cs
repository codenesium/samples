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

                Task<List<ProductCostHistory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4f477672fb6e34e1252bda15148e0c87</Hash>
</Codenesium>*/