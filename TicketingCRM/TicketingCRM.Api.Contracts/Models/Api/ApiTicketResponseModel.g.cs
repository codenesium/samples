using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTicketResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string publicId,
                        int ticketStatusId)
                {
                        this.Id = id;
                        this.PublicId = publicId;
                        this.TicketStatusId = ticketStatusId;

                        this.TicketStatusIdEntity = nameof(ApiResponse.TicketStatus);
                }

                public int Id { get; private set; }

                public string PublicId { get; private set; }

                public int TicketStatusId { get; private set; }

                public string TicketStatusIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>b2530638b1f527c625fbd81d799fe5dd</Hash>
</Codenesium>*/