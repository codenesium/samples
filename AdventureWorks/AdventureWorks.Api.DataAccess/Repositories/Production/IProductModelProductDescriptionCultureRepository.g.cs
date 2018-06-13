using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductModelProductDescriptionCultureRepository
        {
                Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item);

                Task Update(ProductModelProductDescriptionCulture item);

                Task Delete(int productModelID);

                Task<ProductModelProductDescriptionCulture> Get(int productModelID);

                Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ce9610a47e5c579de0a5768aaf0b8309</Hash>
</Codenesium>*/