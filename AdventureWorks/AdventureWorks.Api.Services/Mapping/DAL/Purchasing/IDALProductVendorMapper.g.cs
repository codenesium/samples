using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>7a3ba567dba8a60c8e08df06cece8497</Hash>
</Codenesium>*/