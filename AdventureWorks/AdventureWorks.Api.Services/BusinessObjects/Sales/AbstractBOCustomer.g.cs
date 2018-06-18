using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public abstract class AbstractBOCustomer: AbstractBusinessObject
        {
                public AbstractBOCustomer() : base()
                {
                }

                public virtual void SetProperties(int customerID,
                                                  string accountNumber,
                                                  DateTime modifiedDate,
                                                  Nullable<int> personID,
                                                  Guid rowguid,
                                                  Nullable<int> storeID,
                                                  Nullable<int> territoryID)
                {
                        this.AccountNumber = accountNumber;
                        this.CustomerID = customerID;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                        this.StoreID = storeID;
                        this.TerritoryID = territoryID;
                }

                public string AccountNumber { get; private set; }

                public int CustomerID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public Nullable<int> PersonID { get; private set; }

                public Guid Rowguid { get; private set; }

                public Nullable<int> StoreID { get; private set; }

                public Nullable<int> TerritoryID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>1bb7b2b7844b469f8d15596b0dc27183</Hash>
</Codenesium>*/