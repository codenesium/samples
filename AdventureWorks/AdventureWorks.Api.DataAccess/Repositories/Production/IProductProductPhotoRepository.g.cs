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

                Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>ffeaa71be10716c0dcea26b0dc0ff408</Hash>
</Codenesium>*/