using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductVendorMapper
        {
                ProductVendor MapBOToEF(
                        BOProductVendor bo);

                BOProductVendor MapEFToBO(
                        ProductVendor efProductVendor);

                List<BOProductVendor> MapEFToBO(
                        List<ProductVendor> records);
        }
}

/*<Codenesium>
    <Hash>a88c3d2cfb95cfbf293437f431059b83</Hash>
</Codenesium>*/