using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmployeeDepartmentHistoryMapper: DALAbstractEmployeeDepartmentHistoryMapper, IDALEmployeeDepartmentHistoryMapper
        {
                public DALEmployeeDepartmentHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>15946d3df2a041085ed1918d0ba2aae8</Hash>
</Codenesium>*/