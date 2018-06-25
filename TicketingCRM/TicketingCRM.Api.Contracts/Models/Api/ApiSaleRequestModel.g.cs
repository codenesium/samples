using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleRequestModel : AbstractApiRequestModel
        {
                public ApiSaleRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string ipAddress,
                        string notes,
                        DateTime saleDate,
                        int transactionId)
                {
                        this.IpAddress = ipAddress;
                        this.Notes = notes;
                        this.SaleDate = saleDate;
                        this.TransactionId = transactionId;
                }

                private string ipAddress;

                [Required]
                public string IpAddress
                {
                        get
                        {
                                return this.ipAddress;
                        }

                        set
                        {
                                this.ipAddress = value;
                        }
                }

                private string notes;

                [Required]
                public string Notes
                {
                        get
                        {
                                return this.notes;
                        }

                        set
                        {
                                this.notes = value;
                        }
                }

                private DateTime saleDate;

                [Required]
                public DateTime SaleDate
                {
                        get
                        {
                                return this.saleDate;
                        }

                        set
                        {
                                this.saleDate = value;
                        }
                }

                private int transactionId;

                [Required]
                public int TransactionId
                {
                        get
                        {
                                return this.transactionId;
                        }

                        set
                        {
                                this.transactionId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>ba2eb5bfe3e2a59c97102d0cdb79c6e4</Hash>
</Codenesium>*/