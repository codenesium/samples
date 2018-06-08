using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductProductPhoto: AbstractBusinessObject
        {
                public BOProductProductPhoto() : base()
                {
                }

                public void SetProperties(int productID,
                                          DateTime modifiedDate,
                                          bool primary,
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
        }
}

/*<Codenesium>
    <Hash>b7a1afd095394714b96671ee19e5d723</Hash>
</Codenesium>*/