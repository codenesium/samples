using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>2c03c3c1a710711e8dadbae9e892fc4d</Hash>
</Codenesium>*/