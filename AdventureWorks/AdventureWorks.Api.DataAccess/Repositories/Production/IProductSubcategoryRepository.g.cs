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

                Task<List<ProductSubcategory>> All(int limit = int.MaxValue, int offset = 0);

                Task<ProductSubcategory> ByName(string name);

                Task<List<Product>> Products(int productSubcategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4ba5396690fe6387ee6cc16a00f997cf</Hash>
</Codenesium>*/