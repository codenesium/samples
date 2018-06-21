using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
                        string currencyCode,
                        DateTime modifiedDate)
                {
                        this.CurrencyCode = currencyCode;
                        this.ModifiedDate = modifiedDate;
                }

                private string currencyCode;

                [Required]
                public string CurrencyCode
                {
                        get
                        {
                                return this.currencyCode;
                        }

                        set
                        {
                                this.currencyCode = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>410abaa99f1200be6f7a8cba0db68cb9</Hash>
</Codenesium>*/