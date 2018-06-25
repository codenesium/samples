using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALErrorLogMapper : DALAbstractErrorLogMapper, IDALErrorLogMapper
        {
                public DALErrorLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8a09964a6df23e66126085382337a900</Hash>
</Codenesium>*/