using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOTicket: AbstractBusinessObject
        {
                public BOTicket() : base()
                {
                }

                public void SetProperties(int id,
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
    <Hash>e40ab31a5c098cc0f1e00dd61a137986</Hash>
</Codenesium>*/