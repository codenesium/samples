using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTransactionRequestModel : AbstractApiRequestModel
        {
                public ApiTransactionRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal amount,
                        string gatewayConfirmationNumber,
                        int transactionStatusId)
                {
                        this.Amount = amount;
                        this.GatewayConfirmationNumber = gatewayConfirmationNumber;
                        this.TransactionStatusId = transactionStatusId;
                }

                private decimal amount;

                [Required]
                public decimal Amount
                {
                        get
                        {
                                return this.amount;
                        }

                        set
                        {
                                this.amount = value;
                        }
                }

                private string gatewayConfirmationNumber;

                [Required]
                public string GatewayConfirmationNumber
                {
                        get
                        {
                                return this.gatewayConfirmationNumber;
                        }

                        set
                        {
                                this.gatewayConfirmationNumber = value;
                        }
                }

                private int transactionStatusId;

                [Required]
                public int TransactionStatusId
                {
                        get
                        {
                                return this.transactionStatusId;
                        }

                        set
                        {
                                this.transactionStatusId = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>317ff5d5e08f9dde4c9732653c77afd6</Hash>
</Codenesium>*/