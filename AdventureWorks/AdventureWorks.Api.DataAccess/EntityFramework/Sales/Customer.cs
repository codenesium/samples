using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Customer", Schema="Sales")]
	public partial class Customer: AbstractEntity
	{
		public Customer()
		{}

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
			this.CustomerID = customerID.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.PersonID = personID.ToNullableInt();
			this.Rowguid = rowguid.ToGuid();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("AccountNumber", TypeName="varchar(10)")]
		public string AccountNumber { get; private set; }

		[Key]
		[Column("CustomerID", TypeName="int")]
		public int CustomerID { get; private set; }

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate { get; private set; }

		[Column("PersonID", TypeName="int")]
		public Nullable<int> PersonID { get; private set; }

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; private set; }

		[Column("StoreID", TypeName="int")]
		public Nullable<int> StoreID { get; private set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; private set; }

		[ForeignKey("StoreID")]
		public virtual Store Store { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual SalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>a6a5fe2698c236980ab7af7bf8582bd8</Hash>
</Codenesium>*/