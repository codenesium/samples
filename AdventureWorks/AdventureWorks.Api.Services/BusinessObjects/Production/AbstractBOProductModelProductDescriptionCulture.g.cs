using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOProductModelProductDescriptionCulture : AbstractBusinessObject
        {
                public AbstractBOProductModelProductDescriptionCulture()
                        : base()
                {
                }

                public virtual void SetProperties(int productModelID,
                                                  string cultureID,
                                                  DateTime modifiedDate,
                                                  int productDescriptionID)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductDescriptionID = productDescriptionID;
                        this.ProductModelID = productModelID;
                }

                public string CultureID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductDescriptionID { get; private set; }

                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1c5c31a086bd4c14ca0d8ae05400f47b</Hash>
</Codenesium>*/