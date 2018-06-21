using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductModelIllustrationMapper
        {
                ProductModelIllustration MapBOToEF(
                        BOProductModelIllustration bo);

                BOProductModelIllustration MapEFToBO(
                        ProductModelIllustration efProductModelIllustration);

                List<BOProductModelIllustration> MapEFToBO(
                        List<ProductModelIllustration> records);
        }
}

/*<Codenesium>
    <Hash>f03fd24e3e0a73457f78052595cad790</Hash>
</Codenesium>*/