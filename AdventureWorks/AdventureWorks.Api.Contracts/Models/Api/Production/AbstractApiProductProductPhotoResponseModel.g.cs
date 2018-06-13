using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiProductProductPhotoResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        bool primary,
                        int productID,
                        int productPhotoID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Primary = primary;
                        this.ProductID = productID;
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
    <Hash>f6d312b71debb494d308992996b5a355</Hash>
</Codenesium>*/