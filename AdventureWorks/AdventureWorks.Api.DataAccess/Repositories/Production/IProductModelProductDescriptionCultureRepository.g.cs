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

                Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1f0f1e0ef956fbc7bff287dae4f8c0c8</Hash>
</Codenesium>*/