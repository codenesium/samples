using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>dffc0c3b88f201a2f4d33fd08ac605fb</Hash>
</Codenesium>*/