using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductDescriptionRepository
        {
                Task<ProductDescription> Create(ProductDescription item);

                Task Update(ProductDescription item);

                Task Delete(int productDescriptionID);

                Task<ProductDescription> Get(int productDescriptionID);

                Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>b1b3a889f8e2a5db0008553de9bebe67</Hash>
</Codenesium>*/