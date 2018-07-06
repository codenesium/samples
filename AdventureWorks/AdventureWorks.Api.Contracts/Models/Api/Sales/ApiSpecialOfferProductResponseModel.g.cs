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
        }
}

/*<Codenesium>
    <Hash>458a186754f6bb4af4d94ef75ca54bb7</Hash>
</Codenesium>*/