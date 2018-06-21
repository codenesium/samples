using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOContactType : AbstractBusinessObject
        {
                public AbstractBOContactType()
                        : base()
                {
                }

                public virtual void SetProperties(int contactTypeID,
                                                  DateTime modifiedDate,
                                                  string name)
                {
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                }

                public int ContactTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e9af5ecc2d3fa3442d71416f057328ce</Hash>
</Codenesium>*/