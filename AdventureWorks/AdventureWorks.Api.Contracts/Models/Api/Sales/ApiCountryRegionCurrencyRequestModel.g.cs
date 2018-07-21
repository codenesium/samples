using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCountryRegionCurrencyRequestModel : AbstractApiRequestModel
        {
                public ApiCountryRegionCurrencyRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                }

                [Required]
                [JsonProperty]
                public string CurrencyCode { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ec16b2b2216e69692fa8c9fc3406517f</Hash>
</Codenesium>*/