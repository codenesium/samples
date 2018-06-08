using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALProductModelMapper: DALAbstractProductModelMapper, IDALProductModelMapper
        {
                public DALProductModelMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>69d6a3c5a3f2e04cb81e74812bd1478c</Hash>
</Codenesium>*/