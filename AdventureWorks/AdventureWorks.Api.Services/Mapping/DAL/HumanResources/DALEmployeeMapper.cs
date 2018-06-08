using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmployeeMapper: DALAbstractEmployeeMapper, IDALEmployeeMapper
        {
                public DALEmployeeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7f5580e57dfce8ecc906a12b5a512432</Hash>
</Codenesium>*/