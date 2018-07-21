using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelProductDescriptionCultureRequestModel : AbstractApiRequestModel
        {
                public ApiProductModelProductDescriptionCultureRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        int productDescriptionID)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                }

                [Required]
                [JsonProperty]
                public string CultureID { get; private set; }

                [Required]
                [JsonProperty]
                public DateTime ModifiedDate { get; private set; }

                [Required]
                [JsonProperty]
                public int ProductDescriptionID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>68b869677aa3a983189a0ab406ac1872</Hash>
</Codenesium>*/