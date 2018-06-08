using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>de15b11eb6b0dbdf5148ad3197ca6660</Hash>
</Codenesium>*/