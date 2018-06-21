using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALSaleTicketsMapper : DALAbstractSaleTicketsMapper, IDALSaleTicketsMapper
        {
                public DALSaleTicketsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>f7762dd1aab235cd6b6b6122d239238d</Hash>
</Codenesium>*/