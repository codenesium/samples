using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTransactionRequestModel: AbstractApiRequestModel
        {
                public ApiTransactionRequestModel() : base()
                {
                }

                public void SetProperties(
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
    <Hash>06fb27cad543fea0e855504b36a9bccb</Hash>
</Codenesium>*/