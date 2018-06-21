using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>0d03a909766381c86797042ce9c727bc</Hash>
</Codenesium>*/