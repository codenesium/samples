using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>a7c8f4bc9ab0e6446022a2f653259551</Hash>
</Codenesium>*/