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

                public virtual void SetProperties(
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
    <Hash>6bb546b9ddba4bbd7f20bd158062a200</Hash>
</Codenesium>*/