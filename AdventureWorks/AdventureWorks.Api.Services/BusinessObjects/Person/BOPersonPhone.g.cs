using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOPersonPhone: AbstractBusinessObject
        {
                public BOPersonPhone() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          DateTime modifiedDate,
                                          string phoneNumber,
                                          int phoneNumberTypeID)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.ModifiedDate = modifiedDate;
                        this.PhoneNumber = phoneNumber;
                        this.PhoneNumberTypeID = phoneNumberTypeID;
                }

                public int BusinessEntityID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string PhoneNumber { get; private set; }

                public int PhoneNumberTypeID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>b0353d99d5f5e896bf7f9a2609f54bc2</Hash>
</Codenesium>*/