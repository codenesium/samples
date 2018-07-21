using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleTicketsRequestModel : AbstractApiRequestModel
        {
                public ApiSaleTicketsRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int saleId,
                        int ticketId)
                {
                        this.SaleId = saleId;
                        this.TicketId = ticketId;
                }

                [JsonProperty]
                public int SaleId { get; private set; }

                [JsonProperty]
                public int TicketId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>2915311f61fb02afafec2c9dee82f10a</Hash>
</Codenesium>*/