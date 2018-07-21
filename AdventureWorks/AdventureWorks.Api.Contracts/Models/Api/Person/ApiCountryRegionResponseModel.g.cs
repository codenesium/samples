using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCountryRegionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string countryRegionCode,
                        DateTime modifiedDate,
                        string name)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                [JsonProperty]
                public string CountryRegionCode { get; private set; }

                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [JsonProperty]
                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>8e80aa0688a31a0b8f04e747fe49e2e9</Hash>
</Codenesium>*/