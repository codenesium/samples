using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALEmployeeMapper : DALAbstractEmployeeMapper, IDALEmployeeMapper
        {
                public DALEmployeeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c44170eab4bddb155563811bd4d4e060</Hash>
</Codenesium>*/