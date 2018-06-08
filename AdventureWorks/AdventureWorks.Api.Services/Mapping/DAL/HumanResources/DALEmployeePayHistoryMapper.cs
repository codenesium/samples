using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmployeePayHistoryMapper: DALAbstractEmployeePayHistoryMapper, IDALEmployeePayHistoryMapper
        {
                public DALEmployeePayHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>38d31cbb064942e5b41185e1697625f8</Hash>
</Codenesium>*/