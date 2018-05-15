using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Customer", Schema="Sales")]
	public partial class Customer: AbstractEntityFrameworkPOCO
	{
		public Customer()
		{}

		public void SetProperties(
			int customerID,
			string accountNumber,
			DateTime modifiedDate,
			Nullable<int> personID,
			Guid rowguid,
			Nullable<int> storeID,
			Nullable<int> territoryID)
		{
			this.AccountNumber = accountNumber;
			this.CustomerID = customerID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToNullableInt();
			this.Rowguid = rowguid.ToGuid();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
		}

		[Column("AccountNumber", TypeName="varchar(10)")]
		public string AccountNumber { get; set; }

		[Key]
		[Column("CustomerID", TypeName="int")]
		public int CustomerID { get; set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; set; }

		[Column("PersonID", TypeName="int")]
		public Nullable<int> PersonID { get; set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("StoreID", TypeName="int")]
		public Nullable<int> StoreID { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; set; }

		[ForeignKey("StoreID")]
		public virtual Store Store { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>5f27a8389a52b5cd383a5891e0f19f3e</Hash>
</Codenesium>*/