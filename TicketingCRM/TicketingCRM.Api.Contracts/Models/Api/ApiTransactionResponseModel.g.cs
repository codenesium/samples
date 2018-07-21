using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiTransactionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        decimal amount,
                        string gatewayConfirmationNumber,
                        int transactionStatusId)
                {
                        this.Id = id;
                        this.Amount = amount;
                        this.GatewayConfirmationNumber = gatewayConfirmationNumber;
                        this.TransactionStatusId = transactionStatusId;

                        this.TransactionStatusIdEntity = nameof(ApiResponse.TransactionStatus);
                }

                [Required]
                [JsonProperty]
                public decimal Amount { get; private set; }

                [Required]
                [JsonProperty]
                public string GatewayConfirmationNumber { get; private set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public int TransactionStatusId { get; private set; }

                [JsonProperty]
                public string TransactionStatusIdEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>12f2a58d386a34be67bf7d7d31b4a1f3</Hash>
</Codenesium>*/