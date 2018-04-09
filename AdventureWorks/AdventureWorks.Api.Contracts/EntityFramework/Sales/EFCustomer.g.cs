using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;
namespace AdventureWorksNS.Api.Contracts
{
	[Table("Customer", Schema="Sales")]
	public partial class EFCustomer
	{
		public EFCustomer()
		{}

		public void SetProperties(int customerID,
		                          Nullable<int> personID,
		                          Nullable<int> storeID,
		                          Nullable<int> territoryID,
		                          string accountNumber,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			this.CustomerID = customerID.ToInt();
			this.PersonID = personID.ToNullableInt();
			this.StoreID = storeID.ToNullableInt();
			this.TerritoryID = territoryID.ToNullableInt();
			this.AccountNumber = accountNumber;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		[Column("CustomerID", TypeName="int")]
		public int CustomerID {get; set;}

		[Column("PersonID", TypeName="int")]
		public Nullable<int> PersonID {get; set;}

		[Column("StoreID", TypeName="int")]
		public Nullable<int> StoreID {get; set;}

		[Column("TerritoryID", TypeName="int")]
		public Nullable<int> TerritoryID {get; set;}

		[Column("AccountNumber", TypeName="varchar(10)")]
		public string AccountNumber {get; set;}

		[Column("rowguid", TypeName="uniqueidentifier")]
		public Guid Rowguid {get; set;}

		[Column("ModifiedDate", TypeName="datetime")]
		public DateTime ModifiedDate {get; set;}

		public virtual EFPerson Person { get; set; }

		public virtual EFStore Store { get; set; }

		public virtual EFSalesTerritory SalesTerritory { get; set; }
	}
}

/*<Codenesium>
    <Hash>10489074450c40c207958869294f8337</Hash>
</Codenesium>*/