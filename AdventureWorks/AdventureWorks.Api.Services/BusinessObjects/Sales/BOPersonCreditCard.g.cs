using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOPersonCreditCard: AbstractBusinessObject
        {
                public BOPersonCreditCard() : base()
                {
                }

                public void SetProperties(int businessEntityID,
                                          int creditCardID,
                                          DateTime modifiedDate)
                {
                        this.BusinessEntityID = businessEntityID;
                        this.CreditCardID = creditCardID;
                        this.ModifiedDate = modifiedDate;
                }

                public int BusinessEntityID { get; private set; }

                public int CreditCardID { get; private set; }

                public DateTime ModifiedDate { get; private set; }
        }
}

/*<Codenesium>
    <Hash>ef660ee24ce76b02a6bcffa19cccd7f5</Hash>
</Codenesium>*/