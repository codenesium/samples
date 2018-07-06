using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCustomerResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int customerID,
                        string accountNumber,
                        DateTime modifiedDate,
                        int? personID,
                        Guid rowguid,
                        int? storeID,
                        int? territoryID)
                {
                        this.CustomerID = customerID;
                        this.AccountNumber = accountNumber;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                        this.StoreID = storeID;
                        this.TerritoryID = territoryID;

                        this.StoreIDEntity = nameof(ApiResponse.Stores);
                        this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
                }

                public string AccountNumber { get; private set; }

                public int CustomerID { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int? PersonID { get; private set; }

                public Guid Rowguid { get; private set; }

                public int? StoreID { get; private set; }

                public string StoreIDEntity { get; set; }

                public int? TerritoryID { get; private set; }

                public string TerritoryIDEntity { get; set; }
        }
}

/*<Codenesium>
    <Hash>0369ffa8940823c485c0cd38901f0723</Hash>
</Codenesium>*/