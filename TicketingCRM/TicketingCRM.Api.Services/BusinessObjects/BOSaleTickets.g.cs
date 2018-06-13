using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOSaleTickets: AbstractBusinessObject
        {
                public BOSaleTickets() : base()
                {
                }

                public void SetProperties(int id,
                                          int saleId,
                                          int ticketId)
                {
                        this.Id = id;
                        this.SaleId = saleId;
                        this.TicketId = ticketId;
                }

                public int Id { get; private set; }

                public int SaleId { get; private set; }

                public int TicketId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b5da45621cd04f1839d8cfa0f7e1ba13</Hash>
</Codenesium>*/