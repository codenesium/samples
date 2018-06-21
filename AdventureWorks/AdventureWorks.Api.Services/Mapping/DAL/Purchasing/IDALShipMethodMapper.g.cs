using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALShipMethodMapper
        {
                ShipMethod MapBOToEF(
                        BOShipMethod bo);

                BOShipMethod MapEFToBO(
                        ShipMethod efShipMethod);

                List<BOShipMethod> MapEFToBO(
                        List<ShipMethod> records);
        }
}

/*<Codenesium>
    <Hash>cf26c9e7a2e0d7ad241230b39ad4b326</Hash>
</Codenesium>*/