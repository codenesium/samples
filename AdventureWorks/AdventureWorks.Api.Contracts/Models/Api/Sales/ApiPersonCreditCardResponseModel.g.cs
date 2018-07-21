using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiPersonCreditCardResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int businessEntityID,
                        int creditCardID,
                        DateTime modifiedDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;

                        this.CreditCardIDEntity = nameof(ApiResponse.CreditCards);
                }

                [JsonProperty]
                public int BusinessEntityID { get; private set; }

                [JsonProperty]
                public int CreditCardID { get; private set; }

                [JsonProperty]
                public string CreditCardIDEntity { get; set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c796bb51474c383d88e4f16a917397e6</Hash>
</Codenesium>*/