using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductCategoryRepository
        {
                Task<ProductCategory> Create(ProductCategory item);

                Task Update(ProductCategory item);

                Task Delete(int productCategoryID);

                Task<ProductCategory> Get(int productCategoryID);

                Task<List<ProductCategory>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<ProductCategory> GetName(string name);

                Task<List<ProductSubcategory>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d26e16b89a767cd8698627735d33b8e0</Hash>
</Codenesium>*/