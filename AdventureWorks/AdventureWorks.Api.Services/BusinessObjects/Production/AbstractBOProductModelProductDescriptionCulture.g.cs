using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>46b6f92dcb91a818d9d9832ff5a5f4d8</Hash>
</Codenesium>*/