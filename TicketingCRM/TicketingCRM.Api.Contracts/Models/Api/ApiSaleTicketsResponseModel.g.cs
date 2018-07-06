using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleTicketsResponseModel : AbstractApiResponseModel
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
        }
}

/*<Codenesium>
    <Hash>fc67be217d57550d3b859cc4bae9e1b0</Hash>
</Codenesium>*/