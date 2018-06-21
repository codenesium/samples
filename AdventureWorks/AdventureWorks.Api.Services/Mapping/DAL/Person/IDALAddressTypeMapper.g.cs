using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>2f824b4daa2ab0caff430257abf2cf6f</Hash>
</Codenesium>*/