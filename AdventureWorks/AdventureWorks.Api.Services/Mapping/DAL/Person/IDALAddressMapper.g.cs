using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALAddressMapper
        {
                Address MapBOToEF(
                        BOAddress bo);

                BOAddress MapEFToBO(
                        Address efAddress);

                List<BOAddress> MapEFToBO(
                        List<Address> records);
        }
}

/*<Codenesium>
    <Hash>d1f5c55b419280271bb440c024d8f2c1</Hash>
</Codenesium>*/