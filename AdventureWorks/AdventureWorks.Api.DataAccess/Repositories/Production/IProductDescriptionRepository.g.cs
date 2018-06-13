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

                Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<ProductModelProductDescriptionCulture>> ProductModelProductDescriptionCultures(int productDescriptionID, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>829c9195f562de2e5d33094d0e3e145a</Hash>
</Codenesium>*/