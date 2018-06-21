using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTicketResponseModel : AbstractApiResponseModel
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

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePublicIdValue { get; set; } = true;

                public bool ShouldSerializePublicId()
                {
                        return this.ShouldSerializePublicIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTicketStatusIdValue { get; set; } = true;

                public bool ShouldSerializeTicketStatusId()
                {
                        return this.ShouldSerializeTicketStatusIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializePublicIdValue = false;
                        this.ShouldSerializeTicketStatusIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>ed5eb4ef0ca597eb86651302980c654b</Hash>
</Codenesium>*/