using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOSpecialOfferProduct : AbstractBusinessObject
        {
                public AbstractBOSpecialOfferProduct()
                        : base()
                {
                }

                public virtual void SetProperties(int specialOfferID,
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
    <Hash>abd875b3aae17fb72494471994bc1543</Hash>
</Codenesium>*/