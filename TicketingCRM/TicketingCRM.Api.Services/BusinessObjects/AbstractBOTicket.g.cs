using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTicket: AbstractBusinessObject
        {
                public AbstractBOTicket() : base()
                {
                }

                public virtual void SetProperties(int id,
                                                  string publicId,
                                                  int ticketStatusId)
                {
                        this.Id = id;
                        this.PublicId = publicId;
                        this.TicketStatusId = ticketStatusId;
                }

                public int Id { get; private set; }

                public string PublicId { get; private set; }

                public int TicketStatusId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>cf376e3f9d2053d4c2a00af528ccc715</Hash>
</Codenesium>*/