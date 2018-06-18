using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOIllustration: AbstractBusinessObject
        {
                public AbstractBOIllustration() : base()
                {
                }

                public virtual void SetProperties(int illustrationID,
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
    <Hash>4e29b261db8d2bafba522d602ce9cef6</Hash>
</Codenesium>*/