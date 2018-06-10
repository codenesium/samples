using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public class DALSaleTicketsMapper: DALAbstractSaleTicketsMapper, IDALSaleTicketsMapper
        {
                public DALSaleTicketsMapper()
                {
                }
        }
}

/*<Codenesium>
    <Hash>b720e47d0246232f96be04b3aba3b068</Hash>
</Codenesium>*/