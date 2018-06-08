using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductPhotoRepository
        {
                Task<ProductPhoto> Create(ProductPhoto item);

                Task Update(ProductPhoto item);

                Task Delete(int productPhotoID);

                Task<ProductPhoto> Get(int productPhotoID);

                Task<List<ProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>6e77ef823b97c48be73e7265ae6ad942</Hash>
</Codenesium>*/