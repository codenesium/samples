using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("Customer", Schema="Sales")]
        public partial class Customer : AbstractEntity
        {
                public Customer()
                {
                }

                public virtual void SetProperties(
                        string accountNumber,
                        int customerID,
                        DateTime modifiedDate,
                        int? personID,
                        Guid rowguid,
                        int? storeID,
                        int? territoryID)
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
                public int? PersonID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Column("StoreID")]
                public int? StoreID { get; private set; }

                [Column("TerritoryID")]
                public int? TerritoryID { get; private set; }

                [ForeignKey("StoreID")]
                public virtual Store Store { get; set; }

                [ForeignKey("TerritoryID")]
                public virtual SalesTerritory SalesTerritory { get; set; }
        }
}

/*<Codenesium>
    <Hash>3467b6461e9a2e0bae5077d0dbe356b3</Hash>
</Codenesium>*/