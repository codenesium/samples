using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALWorkOrderMapper: DALAbstractWorkOrderMapper, IDALWorkOrderMapper
        {
                public DALWorkOrderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>08eb633aea597ad94ef3907c669d5ba2</Hash>
</Codenesium>*/