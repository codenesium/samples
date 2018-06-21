using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductModelMapper
        {
                ProductModel MapBOToEF(
                        BOProductModel bo);

                BOProductModel MapEFToBO(
                        ProductModel efProductModel);

                List<BOProductModel> MapEFToBO(
                        List<ProductModel> records);
        }
}

/*<Codenesium>
    <Hash>dbcd7664e9e3a417d0631188025b3546</Hash>
</Codenesium>*/