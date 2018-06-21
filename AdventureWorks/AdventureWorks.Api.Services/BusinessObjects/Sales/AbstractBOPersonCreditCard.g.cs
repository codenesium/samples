using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>cc0d6589ac9d55ff8ded823a87a81606</Hash>
</Codenesium>*/