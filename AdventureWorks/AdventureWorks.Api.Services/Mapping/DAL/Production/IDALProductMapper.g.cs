using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALProductMapper
        {
                Product MapBOToEF(
                        BOProduct bo);

                BOProduct MapEFToBO(
                        Product efProduct);

                List<BOProduct> MapEFToBO(
                        List<Product> records);
        }
}

/*<Codenesium>
    <Hash>3ab972e64ce63b526a149a3e73ee8172</Hash>
</Codenesium>*/