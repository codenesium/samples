using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALScrapReasonMapper
        {
                ScrapReason MapBOToEF(
                        BOScrapReason bo);

                BOScrapReason MapEFToBO(
                        ScrapReason efScrapReason);

                List<BOScrapReason> MapEFToBO(
                        List<ScrapReason> records);
        }
}

/*<Codenesium>
    <Hash>d336c2a81a0c22825782efe601f0c717</Hash>
</Codenesium>*/