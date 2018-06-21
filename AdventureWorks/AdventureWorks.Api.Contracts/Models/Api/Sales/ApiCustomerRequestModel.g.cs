using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiCustomerRequestModel : AbstractApiRequestModel
        {
                public ApiCustomerRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string accountNumber,
                        DateTime modifiedDate,
                        Nullable<int> personID,
                        Guid rowguid,
                        Nullable<int> storeID,
                        Nullable<int> territoryID)
                {
                        this.AccountNumber = accountNumber;
                        this.ModifiedDate = modifiedDate;
                        this.PersonID = personID;
                        this.Rowguid = rowguid;
                        this.StoreID = storeID;
                        this.TerritoryID = territoryID;
                }

                private string accountNumber;

                [Required]
                public string AccountNumber
                {
                        get
                        {
                                return this.accountNumber;
                        }

                        set
                        {
                                this.accountNumber = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private Nullable<int> personID;

                public Nullable<int> PersonID
                {
                        get
                        {
                                return this.personID.IsEmptyOrZeroOrNull() ? null : this.personID;
                        }

                        set
                        {
                                this.personID = value;
                        }
                }

                private Guid rowguid;

                [Required]
                public Guid Rowguid
                {
                        get
                        {
                                return this.rowguid;
                        }

                        set
                        {
                                this.rowguid = value;
                        }
                }

                private Nullable<int> storeID;

                public Nullable<int> StoreID
                {
                        get
                        {
                                return this.storeID.IsEmptyOrZeroOrNull() ? null : this.storeID;
                        }

                        set
                        {
                                this.storeID = value;
                        }
                }

                private Nullable<int> territoryID;

                public Nullable<int> TerritoryID
                {
                        get
                        {
                                return this.territoryID.IsEmptyOrZeroOrNull() ? null : this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>40acba3ae12d173752b519e4bc950825</Hash>
</Codenesium>*/