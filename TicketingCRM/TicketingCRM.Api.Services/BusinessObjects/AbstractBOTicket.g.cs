using Codenesium.DataConversionExtensions;
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
    <Hash>7c940217093e0b8f24e3cdd3419614e4</Hash>
</Codenesium>*/