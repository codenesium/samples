using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>ff54bad4a79fc581fe343174a66e06bd</Hash>
</Codenesium>*/