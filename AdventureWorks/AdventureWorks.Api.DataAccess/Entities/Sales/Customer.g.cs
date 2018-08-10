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
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CustomerID")]
		public int CustomerID { get; private set; }

		[Column("ModifiedDate")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PersonID")]
		public int? PersonID { get; private set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid")]
		public Guid Rowguid { get; private set; }

		[Column("StoreID")]
		public int? StoreID { get; private set; }

		[Column("TerritoryID")]
		public int? TerritoryID { get; private set; }

		[ForeignKey("StoreID")]
		public virtual Store StoreNavigation { get; private set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritoryNavigation { get; private set; }
	}
}

/*<Codenesium>
    <Hash>9d2079a311253324e2387ed643dd07ef</Hash>
</Codenesium>*/