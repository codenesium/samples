using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmployeePayHistoryMapper : DALAbstractEmployeePayHistoryMapper, IDALEmployeePayHistoryMapper
        {
                public DALEmployeePayHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>ab7743b2287d4b60414f8ea30c3cdc42</Hash>
</Codenesium>*/