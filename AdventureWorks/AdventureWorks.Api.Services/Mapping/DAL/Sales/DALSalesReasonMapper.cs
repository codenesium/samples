using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALSalesReasonMapper : DALAbstractSalesReasonMapper, IDALSalesReasonMapper
        {
                public DALSalesReasonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a8363b196504bb475c80d3824a9a447a</Hash>
</Codenesium>*/