using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("Customer", Schema="Sales")]
	public partial class EFCustomer: AbstractEntityFrameworkPOCO
	{
		public EFCustomer()
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
			this.AccountNumber = accountNumber.ToString();
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

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid { get; set; }

		[Column("StoreID", TypeName="int")]
		public Nullable<int> StoreID { get; set; }

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID { get; set; }

		[ForeignKey("StoreID")]
		public virtual EFStore Store { get; set; }

		[ForeignKey("TerritoryID")]
		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>015626ae13e3bc3567788a30fd898c19</Hash>
</Codenesium>*/