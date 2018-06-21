using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALStoreMapper
        {
                Store MapBOToEF(
                        BOStore bo);

                BOStore MapEFToBO(
                        Store efStore);

                List<BOStore> MapEFToBO(
                        List<Store> records);
        }
}

/*<Codenesium>
    <Hash>4bcd67b9142d57dec999830d3ee4df76</Hash>
</Codenesium>*/