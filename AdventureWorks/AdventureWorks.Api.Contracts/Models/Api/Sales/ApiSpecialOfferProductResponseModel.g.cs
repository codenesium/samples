using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiSpecialOfferProductResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int specialOfferID,
                        DateTime modifiedDate,
                        int productID,
                        Guid rowguid)
                {
                        this.SpecialOfferID = specialOfferID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;

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
    <Hash>f99dda7e58ec4a7475382958b91c1ef0</Hash>
</Codenesium>*/