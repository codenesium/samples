using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductProductPhotoRepository
        {
                Task<ProductProductPhoto> Create(ProductProductPhoto item);

                Task Update(ProductProductPhoto item);

                Task Delete(int productID);

                Task<ProductProductPhoto> Get(int productID);

                Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b7ae672f20b302950829fd04d15905b3</Hash>
</Codenesium>*/