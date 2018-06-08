using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALErrorLogMapper
        {
                ErrorLog MapBOToEF(
                        BOErrorLog bo);

                BOErrorLog MapEFToBO(
                        ErrorLog efErrorLog);

                List<BOErrorLog> MapEFToBO(
                        List<ErrorLog> records);
        }
}

/*<Codenesium>
    <Hash>78e228b0951932e4731555ee22cfb823</Hash>
</Codenesium>*/