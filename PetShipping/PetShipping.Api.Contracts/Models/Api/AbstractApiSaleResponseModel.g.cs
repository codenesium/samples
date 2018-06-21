using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public abstract class AbstractApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        decimal amount,
                        int clientId,
                        int id,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Id = id;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;

                        this.ClientIdEntity = nameof(ApiResponse.Clients);
                        this.PetIdEntity = nameof(ApiResponse.Pets);
                }

                public decimal Amount { get; private set; }

                public int ClientId { get; private set; }

                public string ClientIdEntity { get; set; }

                public int Id { get; private set; }

                public string Note { get; private set; }

                public int PetId { get; private set; }

                public string PetIdEntity { get; set; }

                public DateTime SaleDate { get; private set; }

                public int SalesPersonId { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeAmountValue { get; set; } = true;

                public bool ShouldSerializeAmount()
                {
                        return this.ShouldSerializeAmountValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeClientIdValue { get; set; } = true;

                public bool ShouldSerializeClientId()
                {
                        return this.ShouldSerializeClientIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeIdValue { get; set; } = true;

                public bool ShouldSerializeId()
                {
                        return this.ShouldSerializeIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNoteValue { get; set; } = true;

                public bool ShouldSerializeNote()
                {
                        return this.ShouldSerializeNoteValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePetIdValue { get; set; } = true;

                public bool ShouldSerializePetId()
                {
                        return this.ShouldSerializePetIdValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSaleDateValue { get; set; } = true;

                public bool ShouldSerializeSaleDate()
                {
                        return this.ShouldSerializeSaleDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSalesPersonIdValue { get; set; } = true;

                public bool ShouldSerializeSalesPersonId()
                {
                        return this.ShouldSerializeSalesPersonIdValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeAmountValue = false;
                        this.ShouldSerializeClientIdValue = false;
                        this.ShouldSerializeIdValue = false;
                        this.ShouldSerializeNoteValue = false;
                        this.ShouldSerializePetIdValue = false;
                        this.ShouldSerializeSaleDateValue = false;
                        this.ShouldSerializeSalesPersonIdValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>a0b2b41a1bb9a1a252f874ae36cedfbe</Hash>
</Codenesium>*/