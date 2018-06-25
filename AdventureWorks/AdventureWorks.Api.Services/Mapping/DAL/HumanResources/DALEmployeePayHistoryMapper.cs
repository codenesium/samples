using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALEmployeePayHistoryMapper : DALAbstractEmployeePayHistoryMapper, IDALEmployeePayHistoryMapper
        {
                public DALEmployeePayHistoryMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>1016db7c9ef87f5055b18674a05e715e</Hash>
</Codenesium>*/