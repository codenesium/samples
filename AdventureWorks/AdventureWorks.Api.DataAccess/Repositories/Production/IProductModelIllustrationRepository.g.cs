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

                Task<List<ProductModelIllustration>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>fbfc21665c2dbd6bfe05b6f7e098f426</Hash>
</Codenesium>*/