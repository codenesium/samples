using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPersonPhone: AbstractBusinessObject
        {
                public AbstractBOPersonPhone() : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
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
    <Hash>405e644e9ad4afb8cf33d02dd80a224e</Hash>
</Codenesium>*/