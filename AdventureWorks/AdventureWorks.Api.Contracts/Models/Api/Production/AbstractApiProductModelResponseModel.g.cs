using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductModelResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        string catalogDescription,
                        string instructions,
                        DateTime modifiedDate,
                        string name,
                        int productModelID,
                        Guid rowguid)
                {
                        this.CatalogDescription = catalogDescription;
                        this.Instructions = instructions;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductModelID = productModelID;
                        this.Rowguid = rowguid;
                }

                public string CatalogDescription { get; private set; }

                public string Instructions { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductModelID { get; private set; }

                public Guid Rowguid { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeCatalogDescriptionValue { get; set; } = true;

                public bool ShouldSerializeCatalogDescription()
                {
                        return this.ShouldSerializeCatalogDescriptionValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeInstructionsValue { get; set; } = true;

                public bool ShouldSerializeInstructions()
                {
                        return this.ShouldSerializeInstructionsValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeNameValue { get; set; } = true;

                public bool ShouldSerializeName()
                {
                        return this.ShouldSerializeNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductModelIDValue { get; set; } = true;

                public bool ShouldSerializeProductModelID()
                {
                        return this.ShouldSerializeProductModelIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeCatalogDescriptionValue = false;
                        this.ShouldSerializeInstructionsValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProductModelIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>fea4a3c7f55ad1b3d6da552f5c3047d6</Hash>
</Codenesium>*/