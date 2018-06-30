using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductDescriptionResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productDescriptionID,
                        string description,
                        DateTime modifiedDate,
                        Guid rowguid)
                {
                        this.ProductDescriptionID = productDescriptionID;
                        this.Description = description;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public string Description { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductDescriptionID { get; private set; }

                public Guid Rowguid { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeDescriptionValue { get; set; } = true;

                public bool ShouldSerializeDescription()
                {
                        return this.ShouldSerializeDescriptionValue;
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
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeDescriptionValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductDescriptionIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d8f1ef4be8975089cf45792447690b4c</Hash>
</Codenesium>*/