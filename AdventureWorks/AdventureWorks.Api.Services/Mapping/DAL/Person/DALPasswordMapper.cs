using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALPasswordMapper: DALAbstractPasswordMapper, IDALPasswordMapper
        {
                public DALPasswordMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0e0a9b0f1e2e183d4d15c114bd870606</Hash>
</Codenesium>*/