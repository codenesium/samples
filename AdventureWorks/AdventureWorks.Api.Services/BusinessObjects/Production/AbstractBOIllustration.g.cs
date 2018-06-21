using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>7de2fdb1b8be068847c74b140ab48b04</Hash>
</Codenesium>*/