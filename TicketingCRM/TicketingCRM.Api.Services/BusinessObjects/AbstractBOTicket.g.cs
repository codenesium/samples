using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOTicket : AbstractBusinessObject
        {
                public AbstractBOTicket()
                        : base()
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
    <Hash>8599378b0c29d3ee7bdb92dc3c935c46</Hash>
</Codenesium>*/