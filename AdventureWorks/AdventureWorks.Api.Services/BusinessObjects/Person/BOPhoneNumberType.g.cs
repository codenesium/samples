using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOPhoneNumberType: AbstractBusinessObject
        {
                public BOPhoneNumberType() : base()
                {
                }

                public void SetProperties(int phoneNumberTypeID,
                                          DateTime modifiedDate,
                                          string name)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b734d4da7fc3e4f5e1a02659169446ca</Hash>
</Codenesium>*/