using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOContactType: AbstractBusinessObject
        {
                public BOContactType() : base()
                {
                }

                public void SetProperties(int contactTypeID,
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
    <Hash>488e7e38ab0d04a04b3514d880297971</Hash>
</Codenesium>*/