using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALBusinessEntityAddressMapper
        {
                BusinessEntityAddress MapBOToEF(
                        BOBusinessEntityAddress bo);

                BOBusinessEntityAddress MapEFToBO(
                        BusinessEntityAddress efBusinessEntityAddress);

                List<BOBusinessEntityAddress> MapEFToBO(
                        List<BusinessEntityAddress> records);
        }
}

/*<Codenesium>
    <Hash>4db441e90ac698dcd261b86f5a54ce5f</Hash>
</Codenesium>*/