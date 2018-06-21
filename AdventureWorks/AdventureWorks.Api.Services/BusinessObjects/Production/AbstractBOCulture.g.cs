using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCulture : AbstractBusinessObject
        {
                public AbstractBOCulture()
                        : base()
                {
                }

                public virtual void SetProperties(string cultureID,
                                                  DateTime modifiedDate,
                                                  string name)
                {
                        this.CultureID = cultureID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public string CultureID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7a2d2d0a0dd806af2aad5a6e4d46f6fd</Hash>
</Codenesium>*/