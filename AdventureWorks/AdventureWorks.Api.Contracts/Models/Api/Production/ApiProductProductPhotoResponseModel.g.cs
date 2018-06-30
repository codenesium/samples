using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductProductPhotoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productID,
                        DateTime modifiedDate,
                        bool primary,
                        int productPhotoID)
                {
                        this.ProductID = productID;
                        this.ModifiedDate = modifiedDate;
                        this.Primary = primary;
                        this.ProductPhotoID = productPhotoID;
                }

                public DateTime ModifiedDate { get; private set; }

                public bool Primary { get; private set; }

                public int ProductID { get; private set; }

                public int ProductPhotoID { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializePrimaryValue { get; set; } = true;

                public bool ShouldSerializePrimary()
                {
                        return this.ShouldSerializePrimaryValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductPhotoIDValue { get; set; } = true;

                public bool ShouldSerializeProductPhotoID()
                {
                        return this.ShouldSerializeProductPhotoIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializePrimaryValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeProductPhotoIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>feae824c17e81b7b1f59a41671f81d8c</Hash>
</Codenesium>*/