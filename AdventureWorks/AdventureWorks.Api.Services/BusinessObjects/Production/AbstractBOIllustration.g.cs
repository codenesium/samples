using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOIllustration : AbstractBusinessObject
        {
                public AbstractBOIllustration()
                        : base()
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
    <Hash>38b191936a3a27f42ee81f1929eb628b</Hash>
</Codenesium>*/