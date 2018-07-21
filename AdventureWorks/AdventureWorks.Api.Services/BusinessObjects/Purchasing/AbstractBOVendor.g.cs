using Codenesium.DataConversionExtensions;
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
                                                  bool preferredVendorStatu,
                                                  string purchasingWebServiceURL)
                {
                        this.AccountNumber = accountNumber;
                        this.ActiveFlag = activeFlag;
                        this.BusinessEntityID = businessEntityID;
                        this.CreditRating = creditRating;
                        this.ModifiedDate = modifiedDate;
                        this.Name = name;
                        this.PreferredVendorStatu = preferredVendorStatu;
                        this.PurchasingWebServiceURL = purchasingWebServiceURL;
                }

                public string AccountNumber { get; private set; }

                public bool ActiveFlag { get; private set; }

                public int BusinessEntityID { get; private set; }

                public int CreditRating { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public string Name { get; private set; }

                public bool PreferredVendorStatu { get; private set; }

                public string PurchasingWebServiceURL { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7fd1a1f662a20322b85ea9a0490fbbbd</Hash>
</Codenesium>*/