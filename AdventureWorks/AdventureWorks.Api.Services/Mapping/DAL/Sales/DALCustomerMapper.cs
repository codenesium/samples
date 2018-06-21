using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
        {
                public DALCustomerMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>7ee88b8330d473e5b946c8d4340bb223</Hash>
</Codenesium>*/