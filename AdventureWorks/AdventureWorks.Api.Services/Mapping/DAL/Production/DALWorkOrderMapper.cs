using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALWorkOrderMapper : DALAbstractWorkOrderMapper, IDALWorkOrderMapper
        {
                public DALWorkOrderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>dfe0e8196196161190584cd9103e88ad</Hash>
</Codenesium>*/