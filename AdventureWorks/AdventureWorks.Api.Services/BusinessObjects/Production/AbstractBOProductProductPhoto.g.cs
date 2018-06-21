using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductProductPhoto : AbstractBusinessObject
        {
                public AbstractBOProductProductPhoto()
                        : base()
                {
                }

                public virtual void SetProperties(int productID,
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
    <Hash>62a0b63b8795f4f7f78e6b34dc6102c1</Hash>
</Codenesium>*/