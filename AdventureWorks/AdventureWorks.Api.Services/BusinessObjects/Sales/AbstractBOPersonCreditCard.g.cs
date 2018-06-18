using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOPersonCreditCard: AbstractBusinessObject
        {
                public AbstractBOPersonCreditCard() : base()
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
    <Hash>e955477b80be13f8fe88e0890e851be9</Hash>
</Codenesium>*/