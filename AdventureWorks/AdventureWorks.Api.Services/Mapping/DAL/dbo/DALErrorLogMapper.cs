using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALErrorLogMapper : DALAbstractErrorLogMapper, IDALErrorLogMapper
        {
                public DALErrorLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>86e8b0c76d9b52693b39a7a1cf8abc10</Hash>
</Codenesium>*/