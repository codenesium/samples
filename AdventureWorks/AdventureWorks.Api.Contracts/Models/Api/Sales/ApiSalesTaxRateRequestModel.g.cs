using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSalesTaxRateRequestModel : AbstractApiRequestModel
        {
                public ApiSalesTaxRateRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid,
                        int stateProvinceID,
                        decimal taxRate,
                        int taxType)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                        this.StateProvinceID = stateProvinceID;
                        this.TaxRate = taxRate;
                        this.TaxType = taxType;
                }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public string Name { get; private set; }

                [Required]
                [JsonProperty]
                public Guid Rowguid { get; private set; }

                [Required]
                [JsonProperty]
                public int StateProvinceID { get; private set; }

                [Required]
                [JsonProperty]
                public decimal TaxRate { get; private set; }

                [Required]
                [JsonProperty]
                public int TaxType { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c411948b6b1e38a68bcaea5a7ed294ff</Hash>
</Codenesium>*/