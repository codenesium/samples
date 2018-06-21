using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesOrderDetailMapper : DALAbstractSalesOrderDetailMapper, IDALSalesOrderDetailMapper
        {
                public DALSalesOrderDetailMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>21afafa1ed84d31cfe9a07eb583be5cf</Hash>
</Codenesium>*/