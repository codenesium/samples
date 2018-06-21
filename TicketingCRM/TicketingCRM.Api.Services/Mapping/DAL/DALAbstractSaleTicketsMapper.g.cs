using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
        public abstract class DALAbstractSaleTicketsMapper
        {
                public virtual SaleTickets MapBOToEF(
                        BOSaleTickets bo)
                {
                        SaleTickets efSaleTickets = new SaleTickets();
                        efSaleTickets.SetProperties(
                                bo.Id,
                                bo.SaleId,
                                bo.TicketId);
                        return efSaleTickets;
                }

                public virtual BOSaleTickets MapEFToBO(
                        SaleTickets ef)
                {
                        var bo = new BOSaleTickets();

                        bo.SetProperties(
                                ef.Id,
                                ef.SaleId,
                                ef.TicketId);
                        return bo;
                }

                public virtual List<BOSaleTickets> MapEFToBO(
                        List<SaleTickets> records)
                {
                        List<BOSaleTickets> response = new List<BOSaleTickets>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c83750019601b556744768c469013f36</Hash>
</Codenesium>*/