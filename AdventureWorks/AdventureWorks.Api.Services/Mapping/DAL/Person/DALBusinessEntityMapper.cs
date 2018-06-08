using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALBusinessEntityMapper: DALAbstractBusinessEntityMapper, IDALBusinessEntityMapper
        {
                public DALBusinessEntityMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b462d2287a2ed48500ab7135973d0c13</Hash>
</Codenesium>*/