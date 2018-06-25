using Codenesium.DataConversionExtensions;
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
    <Hash>7b180f9d378ca00d62b5a6324015f1bd</Hash>
</Codenesium>*/