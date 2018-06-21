using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPhoneNumberType : AbstractBusinessObject
        {
                public AbstractBOPhoneNumberType()
                        : base()
                {
                }

                public virtual void SetProperties(int phoneNumberTypeID,
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
    <Hash>ff50b0072b05e128fb3360c9278ba954</Hash>
</Codenesium>*/