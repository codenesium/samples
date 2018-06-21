using Codenesium.DataConversionExtensions;
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
    <Hash>e8351dc2c7cd1ffc5a7a586798d3272f</Hash>
</Codenesium>*/