using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelProductDescriptionCultureResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string cultureID,
                        DateTime modifiedDate,
                        int productDescriptionID,
                        int productModelID)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.ProductModelID = productModelID;
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
    <Hash>048dc57deefb4598a1ad90827c8c68c2</Hash>
</Codenesium>*/