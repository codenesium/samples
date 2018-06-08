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

                Task<List<ProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>8796527cd62efb546985d201fc54acf2</Hash>
</Codenesium>*/