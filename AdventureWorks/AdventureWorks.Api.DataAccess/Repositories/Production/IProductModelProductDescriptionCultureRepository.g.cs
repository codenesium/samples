using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductModelProductDescriptionCultureRepository
        {
                Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item);

                Task Update(ProductModelProductDescriptionCulture item);

                Task Delete(int productModelID);

                Task<ProductModelProductDescriptionCulture> Get(int productModelID);

                Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e9a9f070f6c83d4d564e91d877fb140a</Hash>
</Codenesium>*/