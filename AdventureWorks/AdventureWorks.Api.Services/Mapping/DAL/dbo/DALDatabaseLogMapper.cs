using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALDatabaseLogMapper : DALAbstractDatabaseLogMapper, IDALDatabaseLogMapper
        {
                public DALDatabaseLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>370589ed5a6a0871f7bd35a93947504c</Hash>
</Codenesium>*/