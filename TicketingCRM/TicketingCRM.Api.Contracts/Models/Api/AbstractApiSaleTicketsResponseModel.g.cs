using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiSaleTicketsResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        int saleId,
                        int ticketId)
                {
                        this.Id = id;
                        this.SaleId = saleId;
                        this.TicketId = ticketId;

                        this.SaleIdEntity = nameof(ApiResponse.Sales);
                        this.TicketIdEntity = nameof(ApiResponse.Tickets);
                }

                public int Id { get; private set; }

                public int SaleId { get; private set; }

                public string SaleIdEntity { get; set; }

                public int TicketId { get; private set; }

                public string TicketIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSaleIdValue { get; set; } = true;

                public bool ShouldSerializeSaleId()
                {
                        return this.ShouldSerializeSaleIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTicketIdValue { get; set; } = true;

                public bool ShouldSerializeTicketId()
                {
                        return this.ShouldSerializeTicketIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeSaleIdValue = false;
                        this.ShouldSerializeTicketIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>02b26d83bb520be7a3fa5acb13c30947</Hash>
</Codenesium>*/