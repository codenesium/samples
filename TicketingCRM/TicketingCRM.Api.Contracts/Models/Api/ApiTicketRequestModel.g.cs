using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTicketRequestModel : AbstractApiRequestModel
        {
                public ApiTicketRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string publicId,
                        int ticketStatusId)
                {
                        this.PublicId = publicId;
                        this.TicketStatusId = ticketStatusId;
                }

                [JsonProperty]
                public string PublicId { get; private set; }

                [JsonProperty]
                public int TicketStatusId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7ed5380ccc5a99169350711b037a0faa</Hash>
</Codenesium>*/