using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductSubcategoryRepository
        {
                Task<ProductSubcategory> Create(ProductSubcategory item);

                Task Update(ProductSubcategory item);

                Task Delete(int productSubcategoryID);

                Task<ProductSubcategory> Get(int productSubcategoryID);

                Task<List<ProductSubcategory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ProductSubcategory> GetName(string name);

                Task<List<Product>> Products(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fb52f7dc405f1715cd198e590941debb</Hash>
</Codenesium>*/