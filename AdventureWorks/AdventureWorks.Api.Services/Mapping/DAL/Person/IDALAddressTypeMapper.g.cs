using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALAddressTypeMapper
        {
                AddressType MapBOToEF(
                        BOAddressType bo);

                BOAddressType MapEFToBO(
                        AddressType efAddressType);

                List<BOAddressType> MapEFToBO(
                        List<AddressType> records);
        }
}

/*<Codenesium>
    <Hash>47120c531d8ca710aee16fc135246f19</Hash>
</Codenesium>*/