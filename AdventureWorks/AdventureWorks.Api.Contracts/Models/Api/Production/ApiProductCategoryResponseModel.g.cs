using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductCategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productCategoryID,
                        DateTime modifiedDate,
                        string name,
                        Guid rowguid)
                {
                        this.ProductCategoryID = productCategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public Guid Rowguid { get; private set; }

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
                public bool ShouldSerializeProductCategoryIDValue { get; set; } = true;

                public bool ShouldSerializeProductCategoryID()
                {
                        return this.ShouldSerializeProductCategoryIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeNameValue = false;
                        this.ShouldSerializeProductCategoryIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>f6c4cc1a710783ca71d0ef2691f2704e</Hash>
</Codenesium>*/