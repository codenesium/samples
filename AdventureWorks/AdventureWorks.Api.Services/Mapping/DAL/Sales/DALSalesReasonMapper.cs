using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesReasonMapper: DALAbstractSalesReasonMapper, IDALSalesReasonMapper
        {
                public DALSalesReasonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>647f82e211f11e3c41f5f8142f3c3fbf</Hash>
</Codenesium>*/