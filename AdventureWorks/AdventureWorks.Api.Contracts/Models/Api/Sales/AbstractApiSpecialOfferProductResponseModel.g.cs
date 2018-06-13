using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorksNS.Api.Contracts
{
        public abstract class AbstractApiSpecialOfferProductResponseModel: AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        DateTime modifiedDate,
                        int productID,
                        Guid rowguid,
                        int specialOfferID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SpecialOfferID = specialOfferID;

                        this.SpecialOfferIDEntity = nameof(ApiResponse.SpecialOffers);
                }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SpecialOfferID { get; private set; }

                public string SpecialOfferIDEntity { get; set; }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductIDValue { get; set; } = true;

                public bool ShouldSerializeProductID()
                {
                        return this.ShouldSerializeProductIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeRowguidValue { get; set; } = true;

                public bool ShouldSerializeRowguid()
                {
                        return this.ShouldSerializeRowguidValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

                public bool ShouldSerializeSpecialOfferID()
                {
                        return this.ShouldSerializeSpecialOfferIDValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductIDValue = false;
                        this.ShouldSerializeRowguidValue = false;
                        this.ShouldSerializeSpecialOfferIDValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>44c6eb2b35a2437b54f5055adff0575a</Hash>
</Codenesium>*/