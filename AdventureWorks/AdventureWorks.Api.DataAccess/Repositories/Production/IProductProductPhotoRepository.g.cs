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

                Task<List<ProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>37ce4c2ecd09a3dc03a78984bb819bd2</Hash>
</Codenesium>*/