using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductSubcategoryResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productSubcategoryID,
                        DateTime modifiedDate,
                        string name,
                        int productCategoryID,
                        Guid rowguid)
                {
                        this.ProductSubcategoryID = productSubcategoryID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.ProductCategoryID = productCategoryID;
                        this.Rowguid = rowguid;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int ProductCategoryID { get; private set; }

                public int ProductSubcategoryID { get; private set; }

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
                public bool ShouldSerializeProductSubcategoryIDValue { get; set; } = true;

                public bool ShouldSerializeProductSubcategoryID()
                {
                        return this.ShouldSerializeProductSubcategoryIDValue;
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
                        this.ShouldSerializeProductSubcategoryIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>d05233a5b29cddbeb1a9162cdb035d47</Hash>
</Codenesium>*/