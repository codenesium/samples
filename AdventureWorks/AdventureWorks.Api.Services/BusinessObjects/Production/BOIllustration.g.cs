using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOIllustration: AbstractBusinessObject
        {
                public BOIllustration() : base()
                {
                }

                public void SetProperties(int illustrationID,
                                          string diagram,
                                          DateTime modifiedDate)
                {
                        this.Diagram = diagram;
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                }

                public string Diagram { get; private set; }

                public int IllustrationID { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f626d4e8bd5bf0ce84c18175cd923bf2</Hash>
</Codenesium>*/