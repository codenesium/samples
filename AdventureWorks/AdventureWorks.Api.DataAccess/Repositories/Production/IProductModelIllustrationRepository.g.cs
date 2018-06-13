using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductModelIllustrationRepository
        {
                Task<ProductModelIllustration> Create(ProductModelIllustration item);

                Task Update(ProductModelIllustration item);

                Task Delete(int productModelID);

                Task<ProductModelIllustration> Get(int productModelID);

                Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>116eba5e02c7e91099515fd0bc016fc4</Hash>
</Codenesium>*/