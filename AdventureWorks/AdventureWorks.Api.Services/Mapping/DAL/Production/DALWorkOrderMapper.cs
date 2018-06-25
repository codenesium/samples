using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALWorkOrderMapper : DALAbstractWorkOrderMapper, IDALWorkOrderMapper
        {
                public DALWorkOrderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>6db12eb219b76ba5926a4f1aab472f85</Hash>
</Codenesium>*/