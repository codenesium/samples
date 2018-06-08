using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOEmailAddress: AbstractBusinessObject
        {
                public BOEmailAddress() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          string emailAddress1,
                                          int emailAddressID,
                                          DateTime modifiedDate,
                                          Guid rowguid)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.EmailAddress1 = emailAddress1;
                        this.EmailAddressID = emailAddressID;
                        this.ModifiedDate = modifiedDate;
                        this.Rowguid = rowguid;
                }

                public int BusinessEntityID { get; private set; }

                public string EmailAddress1 { get; private set; }

                public int EmailAddressID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Guid Rowguid { get; private set; }
        }
}

/*<Codenesium>
    <Hash>c701584fc5ff23466f836ad88448d44e</Hash>
</Codenesium>*/