using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALSalesOrderHeaderMapper : DALAbstractSalesOrderHeaderMapper, IDALSalesOrderHeaderMapper
        {
                public DALSalesOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7ef26722d7ab5fc745d9cdb4c72daf14</Hash>
</Codenesium>*/