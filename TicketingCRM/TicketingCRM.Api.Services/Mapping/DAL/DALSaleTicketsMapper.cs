using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public partial class DALSaleTicketsMapper : DALAbstractSaleTicketsMapper, IDALSaleTicketsMapper
        {
                public DALSaleTicketsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>01993c69b604cd6de66d74708db17817</Hash>
</Codenesium>*/