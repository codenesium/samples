using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductModelProductDescriptionCulture: AbstractBusinessObject
        {
                public BOProductModelProductDescriptionCulture() : base()
                {
                }

                public void SetProperties(int productModelID,
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
    <Hash>d4725dbf991504cd8fec991ff6c433a1</Hash>
</Codenesium>*/