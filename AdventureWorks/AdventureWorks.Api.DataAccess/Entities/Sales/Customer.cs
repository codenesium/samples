using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Customer", Schema="Sales")]
        public partial class Customer : AbstractEntity
        {
                public Customer()
                {
                }

                public void SetProperties(
                        string accountNumber,
                        int customerID,
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

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("AccountNumber")]
                public string AccountNumber { get; private set; }

                [Key]
                [Column("CustomerID")]
                public int CustomerID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("PersonID")]
                public Nullable<int> PersonID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("StoreID")]
                public Nullable<int> StoreID { get; private set; }

                [Column("TerritoryID")]
                public Nullable<int> TerritoryID { get; private set; }

                [ForeignKey("StoreID")]
                public virtual Store Store { get; set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>86382db9eeb72d12834c9ee6c27c5eca</Hash>
</Codenesium>*/