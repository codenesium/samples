using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductModelIllustration : AbstractBusinessObject
        {
                public AbstractBOProductModelIllustration()
                        : base()
                {
                }

                public virtual void SetProperties(int productModelID,
                                                  int illustrationID,
                                                  DateTime modifiedDate)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductModelID = productModelID;
                }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>66343f5e51cf3f1ab48abbf2889f4b41</Hash>
</Codenesium>*/