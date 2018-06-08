using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALErrorLogMapper: DALAbstractErrorLogMapper, IDALErrorLogMapper
        {
                public DALErrorLogMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5de81682b6acc57e6979320e18b2c844</Hash>
</Codenesium>*/