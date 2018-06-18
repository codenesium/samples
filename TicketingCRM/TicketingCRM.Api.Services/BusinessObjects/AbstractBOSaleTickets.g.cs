using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOSaleTickets: AbstractBusinessObject
        {
                public AbstractBOSaleTickets() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>f72d8641c82c59a5c7c1607c77df8808</Hash>
</Codenesium>*/