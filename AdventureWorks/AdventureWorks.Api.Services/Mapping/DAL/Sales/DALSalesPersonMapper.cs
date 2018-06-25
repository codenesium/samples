using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALSalesPersonMapper : DALAbstractSalesPersonMapper, IDALSalesPersonMapper
        {
                public DALSalesPersonMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>5391abbd5c468f3f493b71bdc71a99dc</Hash>
</Codenesium>*/