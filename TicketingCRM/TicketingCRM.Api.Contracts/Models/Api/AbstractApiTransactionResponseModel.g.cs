using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace TicketingCRMNS.Api.Contracts
{
        public abstract class AbstractApiTransactionResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal amount,
                        string gatewayConfirmationNumber,
                        int id,
                        int transactionStatusId)
                {
                        this.Amount = amount;
                        this.GatewayConfirmationNumber = gatewayConfirmationNumber;
                        this.Id = id;
                        this.TransactionStatusId = transactionStatusId;

                        this.TransactionStatusIdEntity = nameof(ApiResponse.TransactionStatus);
                }

                public decimal Amount { get; private set; }

                public string GatewayConfirmationNumber { get; private set; }

                public int Id { get; private set; }

                public int TransactionStatusId { get; private set; }

                public string TransactionStatusIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeAmountValue { get; set; } = true;

                public bool ShouldSerializeAmount()
                {
                        return this.ShouldSerializeAmountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeGatewayConfirmationNumberValue { get; set; } = true;

                public bool ShouldSerializeGatewayConfirmationNumber()
                {
                        return this.ShouldSerializeGatewayConfirmationNumberValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTransactionStatusIdValue { get; set; } = true;

                public bool ShouldSerializeTransactionStatusId()
                {
                        return this.ShouldSerializeTransactionStatusIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAmountValue = false;
                        this.ShouldSerializeGatewayConfirmationNumberValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeTransactionStatusIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>300409610ae82b84965481ede0746e83</Hash>
</Codenesium>*/