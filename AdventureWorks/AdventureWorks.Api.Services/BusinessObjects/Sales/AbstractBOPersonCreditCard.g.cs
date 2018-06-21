using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPersonCreditCard : AbstractBusinessObject
        {
                public AbstractBOPersonCreditCard()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
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
    <Hash>555489efd4e253a589dff8b67c4e8b96</Hash>
</Codenesium>*/