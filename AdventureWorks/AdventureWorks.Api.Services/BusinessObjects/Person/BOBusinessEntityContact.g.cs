using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOBusinessEntityContact: AbstractBusinessObject
        {
                public BOBusinessEntityContact() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          int contactTypeID,
                                          DateTime modifiedDate,
                                          int personID,
                                          Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ContactTypeID = contactTypeID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public int ContactTypeID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int PersonID { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>adb969beb4fcdda57833cac6ad052283</Hash>
</Codenesium>*/