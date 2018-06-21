using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>c9f30e32a990feebf4cba50149fb2f10</Hash>
</Codenesium>*/