using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorksNS.Api.Services
{
        public partial class DALCustomerMapper : DALAbstractCustomerMapper, IDALCustomerMapper
        {
                public DALCustomerMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>a03f6d68025df322260ffa49d1ca9531</Hash>
</Codenesium>*/