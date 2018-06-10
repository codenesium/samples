using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public interface IDALSaleTicketsMapper
        {
                SaleTickets MapBOToEF(
                        BOSaleTickets bo);

                BOSaleTickets MapEFToBO(
                        SaleTickets efSaleTickets);

                List<BOSaleTickets> MapEFToBO(
                        List<SaleTickets> records);
        }
}

/*<Codenesium>
    <Hash>2c3c303353463e8542bceca618416c1c</Hash>
</Codenesium>*/