using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductDescriptionMapper
        {
                ProductDescription MapBOToEF(
                        BOProductDescription bo);

                BOProductDescription MapEFToBO(
                        ProductDescription efProductDescription);

                List<BOProductDescription> MapEFToBO(
                        List<ProductDescription> records);
        }
}

/*<Codenesium>
    <Hash>c04501551a2981669a2115d173cea2c5</Hash>
</Codenesium>*/