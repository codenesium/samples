using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALShiftMapper : DALAbstractShiftMapper, IDALShiftMapper
        {
                public DALShiftMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c680dd24ca986374ffcd965123c527d0</Hash>
</Codenesium>*/