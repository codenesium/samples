using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALBusinessEntityMapper : DALAbstractBusinessEntityMapper, IDALBusinessEntityMapper
        {
                public DALBusinessEntityMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>2c41bd4bf471ef0da802c4d0008a15e8</Hash>
</Codenesium>*/