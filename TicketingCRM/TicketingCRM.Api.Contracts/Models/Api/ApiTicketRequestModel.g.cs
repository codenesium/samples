using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTicketRequestModel: AbstractApiRequestModel
        {
                public ApiTicketRequestModel() : base()
                {
                }

                public void SetProperties(
                        string publicId,
                        int ticketStatusId)
                {
                        this.PublicId = publicId;
                        this.TicketStatusId = ticketStatusId;
                }

                private string publicId;

                [Required]
                public string PublicId
                {
                        get
                        {
                                return this.publicId;
                        }

                        set
                        {
                                this.publicId = value;
                        }
                }

                private int ticketStatusId;

                [Required]
                public int TicketStatusId
                {
                        get
                        {
                                return this.ticketStatusId;
                        }

                        set
                        {
                                this.ticketStatusId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>e9e678861e081beda4e34288cd6bd2cb</Hash>
</Codenesium>*/