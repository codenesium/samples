using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALSalesPersonMapper : DALAbstractSalesPersonMapper, IDALSalesPersonMapper
        {
                public DALSalesPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0b75748d655034f9c450a49282a77052</Hash>
</Codenesium>*/