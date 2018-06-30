using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALTicketStatusMapper : DALAbstractTicketStatusMapper, IDALTicketStatusMapper
        {
                public DALTicketStatusMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>983e35e0be5ed36ce1f27361005c0586</Hash>
</Codenesium>*/