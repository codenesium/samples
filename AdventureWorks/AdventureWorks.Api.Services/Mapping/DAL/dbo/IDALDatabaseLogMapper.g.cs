using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALDatabaseLogMapper
        {
                DatabaseLog MapBOToEF(
                        BODatabaseLog bo);

                BODatabaseLog MapEFToBO(
                        DatabaseLog efDatabaseLog);

                List<BODatabaseLog> MapEFToBO(
                        List<DatabaseLog> records);
        }
}

/*<Codenesium>
    <Hash>a67b0dd98079cc450919ad4c72abfc6e</Hash>
</Codenesium>*/