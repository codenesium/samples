using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiSaleRequestModel : AbstractApiRequestModel
        {
                public ApiSaleRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        decimal amount,
                        string firstName,
                        string lastName,
                        int paymentTypeId,
                        int petId,
                        string phone)
                {
                        this.Amount = amount;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.PaymentTypeId = paymentTypeId;
                        this.PetId = petId;
                        this.Phone = phone;
                }

                [Required]
                [JsonProperty]
                public decimal Amount { get; private set; }

                [Required]
                [JsonProperty]
                public string FirstName { get; private set; }

                [Required]
                [JsonProperty]
                public string LastName { get; private set; }

                [Required]
                [JsonProperty]
                public int PaymentTypeId { get; private set; }

                [Required]
                [JsonProperty]
                public int PetId { get; private set; }

                [Required]
                [JsonProperty]
                public string Phone { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b0895b0a6ef0bf59684a3b2aadd8fe85</Hash>
</Codenesium>*/