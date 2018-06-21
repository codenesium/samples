using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductPhotoRepository
        {
                Task<ProductPhoto> Create(ProductPhoto item);

                Task Update(ProductPhoto item);

                Task Delete(int productPhotoID);

                Task<ProductPhoto> Get(int productPhotoID);

                Task<List<ProductPhoto>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductProductPhoto>> ProductProductPhotoes(int productPhotoID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>d624b71e959fc8ef8cccf87b45eaa7b7</Hash>
</Codenesium>*/