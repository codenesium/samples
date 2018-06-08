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

                Task<List<ProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>c172306048f20cf29837b786d11d2ecd</Hash>
</Codenesium>*/