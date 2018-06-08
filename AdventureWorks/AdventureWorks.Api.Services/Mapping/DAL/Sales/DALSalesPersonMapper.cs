using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesPersonMapper: DALAbstractSalesPersonMapper, IDALSalesPersonMapper
        {
                public DALSalesPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>fe72b6f7d73edb23eb5f77032d61dd65</Hash>
</Codenesium>*/