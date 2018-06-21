using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>43922164e0d282684e9eea66b2017846</Hash>
</Codenesium>*/