using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALTicketMapper : DALAbstractTicketMapper, IDALTicketMapper
        {
                public DALTicketMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>d9ff0cea94cce68d227be6b8f2209348</Hash>
</Codenesium>*/