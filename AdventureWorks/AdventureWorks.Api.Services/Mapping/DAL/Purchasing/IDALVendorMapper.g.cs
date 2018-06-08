using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALVendorMapper
        {
                Vendor MapBOToEF(
                        BOVendor bo);

                BOVendor MapEFToBO(
                        Vendor efVendor);

                List<BOVendor> MapEFToBO(
                        List<Vendor> records);
        }
}

/*<Codenesium>
    <Hash>a579b255cfd449414c94c10d015ced33</Hash>
</Codenesium>*/