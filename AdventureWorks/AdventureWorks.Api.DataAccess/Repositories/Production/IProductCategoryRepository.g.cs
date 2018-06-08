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

                Task<List<ProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

                Task<ProductCategory> GetName(string name);
        }
}

/*<Codenesium>
    <Hash>841b8e35863683c6a546e16b1f8b7b6e</Hash>
</Codenesium>*/