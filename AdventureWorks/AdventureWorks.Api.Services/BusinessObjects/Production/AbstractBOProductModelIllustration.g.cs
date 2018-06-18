using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductModelIllustration: AbstractBusinessObject
        {
                public AbstractBOProductModelIllustration() : base()
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
    <Hash>d02d74c8ea2bb30b5c45cfec846a5762</Hash>
</Codenesium>*/