using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
        public partial class BOCustomer: AbstractBusinessObject
        {
                public BOCustomer() : base()
                {
                }

                public void SetProperties(int customerID,
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
    <Hash>df3c1eee890354fcf06adc5fc309c4a3</Hash>
</Codenesium>*/