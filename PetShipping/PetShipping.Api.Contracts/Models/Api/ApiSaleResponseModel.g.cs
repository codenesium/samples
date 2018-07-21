using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiSaleResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        decimal amount,
                        int clientId,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Id = id;
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;

                        this.ClientIdEntity = nameof(ApiResponse.Clients);
                        this.PetIdEntity = nameof(ApiResponse.Pets);
                }

                [Required]
                [JsonProperty]
                public decimal Amount { get; private set; }

                [Required]
                [JsonProperty]
                public int ClientId { get; private set; }

                [JsonProperty]
                public string ClientIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public int Id { get; private set; }

                [Required]
                [JsonProperty]
                public string Note { get; private set; }

                [Required]
                [JsonProperty]
                public int PetId { get; private set; }

                [JsonProperty]
                public string PetIdEntity { get; set; }

                [Required]
                [JsonProperty]
                public DateTime SaleDate { get; private set; }

                [Required]
                [JsonProperty]
                public int SalesPersonId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9c2ec84f372ce803275aca4bc79cb748</Hash>
</Codenesium>*/