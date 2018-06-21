using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesOrderHeaderMapper : DALAbstractSalesOrderHeaderMapper, IDALSalesOrderHeaderMapper
        {
                public DALSalesOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8410362e152856b93544da2e72effc7e</Hash>
</Codenesium>*/