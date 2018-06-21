using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALEmployeeMapper : DALAbstractEmployeeMapper, IDALEmployeeMapper
        {
                public DALEmployeeMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8de0e9de68c8f9db0db04dda07b65a7a</Hash>
</Codenesium>*/