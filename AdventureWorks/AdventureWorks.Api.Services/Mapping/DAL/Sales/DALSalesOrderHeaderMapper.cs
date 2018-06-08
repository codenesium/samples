using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesOrderHeaderMapper: DALAbstractSalesOrderHeaderMapper, IDALSalesOrderHeaderMapper
        {
                public DALSalesOrderHeaderMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>8922abe2c167bf49be17d496d66097f3</Hash>
</Codenesium>*/