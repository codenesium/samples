using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALTicketMapper : DALAbstractTicketMapper, IDALTicketMapper
        {
                public DALTicketMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>24bed3c8f2c1c0e124d856557194330d</Hash>
</Codenesium>*/