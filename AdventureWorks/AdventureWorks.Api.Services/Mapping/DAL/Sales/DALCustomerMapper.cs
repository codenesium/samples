using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class DALCustomerMapper: DALAbstractCustomerMapper, IDALCustomerMapper
        {
                public DALCustomerMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>510045f8694ce3c75a5741e77af75728</Hash>
</Codenesium>*/