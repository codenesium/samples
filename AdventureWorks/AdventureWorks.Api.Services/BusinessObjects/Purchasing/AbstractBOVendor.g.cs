using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOVendor : AbstractBusinessObject
        {
                public AbstractBOVendor()
                        : base()
                {
                }

                public virtual void SetProperties(int businessEntityID,
                                                  string accountNumber,
                                                  bool activeFlag,
                                                  int creditRating,
                                                  DateTime modifiedDate,
                                                  string name,
                                                  bool preferredVendorStatus,
                                                  string purchasingWebServiceURL)
                {
                        this.AccountNumber = accountNumber;
                        this.ActiveFlag = activeFlag;
                        this.BusinessEntityID = businessEntityID;
                        this.CreditRating = creditRating;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PreferredVendorStatus = preferredVendorStatus;
                        this.PurchasingWebServiceURL = purchasingWebServiceURL;
                }

                public string AccountNumber { get; private set; }

                public bool ActiveFlag { get; private set; }

                public int BusinessEntityID { get; private set; }

                public int CreditRating { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public bool PreferredVendorStatus { get; private set; }

                public string PurchasingWebServiceURL { get; private set; }
        }
}

/*<Codenesium>
    <Hash>14311e712a3434d132497cb11542b7a0</Hash>
</Codenesium>*/