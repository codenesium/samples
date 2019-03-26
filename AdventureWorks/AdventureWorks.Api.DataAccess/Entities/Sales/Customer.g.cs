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
		}

		[MaxLength(10)]
		[Column("AccountNumber")]
		public virtual string AccountNumber { get; private set; }

		[Key]
		[Column("CustomerID")]
		public virtual int CustomerID { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("PersonID")]
		public virtual int? PersonID { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Column("StoreID")]
		public virtual int? StoreID { get; private set; }

		[Column("TerritoryID")]
		public virtual int? TerritoryID { get; private set; }

		[ForeignKey("StoreID")]
		public virtual Store StoreIDNavigation { get; private set; }

		public void SetStoreIDNavigation(Store item)
		{
			this.StoreIDNavigation = item;
		}

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(SalesTerritory item)
		{
			this.TerritoryIDNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>3955616e26a314afaed09e06713ec416</Hash>
</Codenesium>*/