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
    <Hash>bf6bc5cc869e35a4e3f6e18c401d9d86</Hash>
</Codenesium>*/