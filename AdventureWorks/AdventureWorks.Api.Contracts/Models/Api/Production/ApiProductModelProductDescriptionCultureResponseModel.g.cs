using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductModelProductDescriptionCultureResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productModelID,
                        string cultureID,
                        DateTime modifiedDate,
                        int productDescriptionID)
                {
                        this.ProductModelID = productModelID;
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                }

                public string CultureID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductDescriptionID { get; private set; }

                public int ProductModelID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCultureIDValue { get; set; } = true;

                public bool ShouldSerializeCultureID()
                {
                        return this.ShouldSerializeCultureIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductDescriptionIDValue { get; set; } = true;

                public bool ShouldSerializeProductDescriptionID()
                {
                        return this.ShouldSerializeProductDescriptionIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelIDValue { get; set; } = true;

                public bool ShouldSerializeProductModelID()
                {
                        return this.ShouldSerializeProductModelIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCultureIDValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductDescriptionIDValue = false;
                        this.ShouldSerializeProductModelIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>c99c16aeda4dec3c3085f834124c5fd5</Hash>
</Codenesium>*/