using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>00d813372babc98f75358b7c87793a8b</Hash>
</Codenesium>*/