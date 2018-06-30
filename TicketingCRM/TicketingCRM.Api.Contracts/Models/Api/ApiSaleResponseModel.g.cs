using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string ipAddress,
                        string notes,
                        DateTime saleDate,
                        int transactionId)
                {
                        this.Id = id;
                        this.IpAddress = ipAddress;
                        this.Notes = notes;
                        this.SaleDate = saleDate;
                        this.TransactionId = transactionId;

                        this.TransactionIdEntity = nameof(ApiResponse.Transactions);
                }

                public int Id { get; private set; }

                public string IpAddress { get; private set; }

                public string Notes { get; private set; }

                public DateTime SaleDate { get; private set; }

                public int TransactionId { get; private set; }

                public string TransactionIdEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIpAddressValue { get; set; } = true;

                public bool ShouldSerializeIpAddress()
                {
                        return this.ShouldSerializeIpAddressValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNotesValue { get; set; } = true;

                public bool ShouldSerializeNotes()
                {
                        return this.ShouldSerializeNotesValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSaleDateValue { get; set; } = true;

                public bool ShouldSerializeSaleDate()
                {
                        return this.ShouldSerializeSaleDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeTransactionIdValue { get; set; } = true;

                public bool ShouldSerializeTransactionId()
                {
                        return this.ShouldSerializeTransactionIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeIpAddressValue = false;
                        this.ShouldSerializeNotesValue = false;
                        this.ShouldSerializeSaleDateValue = false;
                        this.ShouldSerializeTransactionIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f474032cc063229212ed591466580ff6</Hash>
</Codenesium>*/