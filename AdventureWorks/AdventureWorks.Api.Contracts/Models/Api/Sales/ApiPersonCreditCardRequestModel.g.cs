using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonCreditCardRequestModel : AbstractApiRequestModel
        {
                public ApiPersonCreditCardRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int creditCardID,
                        DateTime modifiedDate)
                {
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;
                }

                [Required]
                [JsonProperty]
                public int CreditCardID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>53d097d2c7179cf11d41e7e9ede7833d</Hash>
</Codenesium>*/