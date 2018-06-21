using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductMapper : DALAbstractProductMapper, IDALProductMapper
        {
                public DALProductMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>bd3ea2c564f2f13d52facf8f66108570</Hash>
</Codenesium>*/