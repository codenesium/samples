using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductDocumentRepository
        {
                Task<ProductDocument> Create(ProductDocument item);

                Task Update(ProductDocument item);

                Task Delete(int productID);

                Task<ProductDocument> Get(int productID);

                Task<List<ProductDocument>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>bb0a766bcbbff7335e1caf824205d7e6</Hash>
</Codenesium>*/