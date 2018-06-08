using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALDatabaseLogMapper: DALAbstractDatabaseLogMapper, IDALDatabaseLogMapper
        {
                public DALDatabaseLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3ef309360ebede63f7eaec3e0dbd3d37</Hash>
</Codenesium>*/