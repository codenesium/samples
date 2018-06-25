using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
        {
                public DALPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d656efd1c1b744e277bd97686de50fa9</Hash>
</Codenesium>*/