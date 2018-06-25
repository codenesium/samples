using Codenesium.DataConversionExtensions;
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

                public virtual void SetProperties(
                        string accountNumber,
                        DateTime modifiedDate,
                        int? personID,
                        Guid rowguid,
                        int? storeID,
                        int? territoryID)
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

                private int? personID;

                public int? PersonID
                {
                        get
                        {
                                return this.personID;
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

                private int? storeID;

                public int? StoreID
                {
                        get
                        {
                                return this.storeID;
                        }

                        set
                        {
                                this.storeID = value;
                        }
                }

                private int? territoryID;

                public int? TerritoryID
                {
                        get
                        {
                                return this.territoryID;
                        }

                        set
                        {
                                this.territoryID = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>5b64ad05e64338c232862553090af182</Hash>
</Codenesium>*/