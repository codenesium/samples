using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IProductModelIllustrationRepository
        {
                Task<ProductModelIllustration> Create(ProductModelIllustration item);

                Task Update(ProductModelIllustration item);

                Task Delete(int productModelID);

                Task<ProductModelIllustration> Get(int productModelID);

                Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a3b8ccda256668b3bf2d27d2e1109355</Hash>
</Codenesium>*/