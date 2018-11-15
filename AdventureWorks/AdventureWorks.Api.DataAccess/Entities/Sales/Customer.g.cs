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
		public virtual Store StoreNavigation { get; private set; }

		public void SetStoreNavigation(Store item)
		{
			this.StoreNavigation = item;
		}

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritoryNavigation { get; private set; }

		public void SetSalesTerritoryNavigation(SalesTerritory item)
		{
			this.SalesTerritoryNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>89963b2ddfffb7f6d4e21dbb05646900</Hash>
</Codenesium>*/