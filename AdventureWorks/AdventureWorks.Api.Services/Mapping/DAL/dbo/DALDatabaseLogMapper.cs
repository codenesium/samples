using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALDatabaseLogMapper : DALAbstractDatabaseLogMapper, IDALDatabaseLogMapper
        {
                public DALDatabaseLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>37d09234d4c22d291b72739c7461cb98</Hash>
</Codenesium>*/