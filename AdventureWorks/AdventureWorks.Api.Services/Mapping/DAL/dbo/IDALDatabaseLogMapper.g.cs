using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>8e53746a21a7c3b803bf51172282575f</Hash>
</Codenesium>*/