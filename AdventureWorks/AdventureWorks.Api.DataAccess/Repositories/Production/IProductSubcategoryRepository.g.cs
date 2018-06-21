using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>e0be65c2dabdfb1f81e9893ee4b8c138</Hash>
</Codenesium>*/