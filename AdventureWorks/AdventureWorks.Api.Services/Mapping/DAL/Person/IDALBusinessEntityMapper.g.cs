using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALBusinessEntityMapper
        {
                BusinessEntity MapBOToEF(
                        BOBusinessEntity bo);

                BOBusinessEntity MapEFToBO(
                        BusinessEntity efBusinessEntity);

                List<BOBusinessEntity> MapEFToBO(
                        List<BusinessEntity> records);
        }
}

/*<Codenesium>
    <Hash>5f1d915e45db71bcb4dea3b71dfc6707</Hash>
</Codenesium>*/