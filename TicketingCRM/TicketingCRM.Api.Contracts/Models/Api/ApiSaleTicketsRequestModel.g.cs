using Codenesium.DataConversionExtensions.AspNetCore;
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

                public void SetProperties(
                        int saleId,
                        int ticketId)
                {
                        this.SaleId = saleId;
                        this.TicketId = ticketId;
                }

                private int saleId;

                [Required]
                public int SaleId
                {
                        get
                        {
                                return this.saleId;
                        }

                        set
                        {
                                this.saleId = value;
                        }
                }

                private int ticketId;

                [Required]
                public int TicketId
                {
                        get
                        {
                                return this.ticketId;
                        }

                        set
                        {
                                this.ticketId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>447442251d4ab63486c796f0708e7c44</Hash>
</Codenesium>*/