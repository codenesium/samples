using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALAdminMapper : DALAbstractAdminMapper, IDALAdminMapper
        {
                public DALAdminMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>89a60afcc998a135a57c50b2896a0b11</Hash>
</Codenesium>*/