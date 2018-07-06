using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCountryRegionCurrencyResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string countryRegionCode,
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CountryRegionCode = countryRegionCode;
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;

                        this.CurrencyCodeEntity = nameof(ApiResponse.Currencies);
                }

                public string CountryRegionCode { get; private set; }

                public string CurrencyCode { get; private set; }

                public string CurrencyCodeEntity { get; set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c4d22fa08b002b7dd0a13db75c8dab83</Hash>
</Codenesium>*/