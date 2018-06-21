using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>af6c7d313c984e213bb1e1a22adba01e</Hash>
</Codenesium>*/