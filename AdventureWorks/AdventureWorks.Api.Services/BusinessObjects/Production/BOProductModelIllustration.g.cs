using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOProductModelIllustration: AbstractBusinessObject
        {
                public BOProductModelIllustration() : base()
                {
                }

                public void SetProperties(int productModelID,
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
    <Hash>7c2724a3e984e45d9d47fb26bf86d11d</Hash>
</Codenesium>*/