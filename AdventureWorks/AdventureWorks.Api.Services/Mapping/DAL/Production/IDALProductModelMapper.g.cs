using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>b810a2daf7ac50ccd585398e8736e654</Hash>
</Codenesium>*/