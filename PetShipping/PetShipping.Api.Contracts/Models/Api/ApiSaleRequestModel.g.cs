using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiSaleRequestModel : AbstractApiRequestModel
        {
                public ApiSaleRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal amount,
                        int clientId,
                        string note,
                        int petId,
                        DateTime saleDate,
                        int salesPersonId)
                {
                        this.Amount = amount;
                        this.ClientId = clientId;
                        this.Note = note;
                        this.PetId = petId;
                        this.SaleDate = saleDate;
                        this.SalesPersonId = salesPersonId;
                }

                [JsonProperty]
                public decimal Amount { get; private set; }

                [JsonProperty]
                public int ClientId { get; private set; }

                [JsonProperty]
                public string Note { get; private set; }

                [JsonProperty]
                public int PetId { get; private set; }

                [JsonProperty]
                public DateTime SaleDate { get; private set; }

                [JsonProperty]
                public int SalesPersonId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8c02fb2423afbb7feca982436a483c23</Hash>
</Codenesium>*/