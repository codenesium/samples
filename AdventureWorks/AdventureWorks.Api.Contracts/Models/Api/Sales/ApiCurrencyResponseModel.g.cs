using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCurrencyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [JsonProperty]
                public string CurrencyCode { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>57de8fe744f25de9da7e9178092988e5</Hash>
</Codenesium>*/