using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTicketStatusMapper : DALAbstractTicketStatusMapper, IDALTicketStatusMapper
        {
                public DALTicketStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>3704e5ae36e2ce1dd6a57bd3680b1b1e</Hash>
</Codenesium>*/