using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALAdminMapper: DALAbstractAdminMapper, IDALAdminMapper
        {
                public DALAdminMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>c1beb8629906d13d15bde9a3b4db639a</Hash>
</Codenesium>*/