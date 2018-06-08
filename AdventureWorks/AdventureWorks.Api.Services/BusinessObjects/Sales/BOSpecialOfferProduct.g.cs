using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOSpecialOfferProduct: AbstractBusinessObject
        {
                public BOSpecialOfferProduct() : base()
                {
                }

                public void SetProperties(int specialOfferID,
                                          DateTime modifiedDate,
                                          int productID,
                                          Guid rowguid)
                {
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SpecialOfferID = specialOfferID;
                }

                public DateTime ModifiedDate { get; private set; }

                public int ProductID { get; private set; }

                public Guid Rowguid { get; private set; }

                public int SpecialOfferID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>186df6e7b89653bab516510c2e7fd6cf</Hash>
</Codenesium>*/