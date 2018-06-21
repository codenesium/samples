using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
    <Hash>86311cb7bfda418c8bc3d253139fd1f7</Hash>
</Codenesium>*/