using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCulture: AbstractBusinessObject
        {
                public AbstractBOCulture() : base()
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
    <Hash>764b95ff0044f4b0f3a124dc8f8294b5</Hash>
</Codenesium>*/