using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>314b8ec687a3de0ea9994ad73331e862</Hash>
</Codenesium>*/