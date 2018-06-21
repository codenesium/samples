using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALPersonMapper : DALAbstractPersonMapper, IDALPersonMapper
        {
                public DALPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>991c14b286db65590612e4a179b4abad</Hash>
</Codenesium>*/