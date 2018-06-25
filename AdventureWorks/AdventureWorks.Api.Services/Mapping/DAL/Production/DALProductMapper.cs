using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALProductMapper : DALAbstractProductMapper, IDALProductMapper
        {
                public DALProductMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>eed099e66286a25cc850443ef13d4f2c</Hash>
</Codenesium>*/