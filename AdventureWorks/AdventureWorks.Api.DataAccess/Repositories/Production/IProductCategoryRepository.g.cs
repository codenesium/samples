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

                Task<List<ProductCategory>> All(int limit = int.MaxValue, int offset = 0);

                Task<ProductCategory> ByName(string name);

                Task<List<ProductSubcategory>> ProductSubcategories(int productCategoryID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1fef6060c38d6fa38c521c4c88baf5d5</Hash>
</Codenesium>*/