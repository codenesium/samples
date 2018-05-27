using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOCustomer: AbstractDTO
	{
		public DTOCustomer() : base()
		{}

		public void SetProperties(int customerID,
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

		public string AccountNumber { get; set; }
		public int CustomerID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Nullable<int> PersonID { get; set; }
		public Guid Rowguid { get; set; }
		public Nullable<int> StoreID { get; set; }
		public Nullable<int> TerritoryID { get; set; }
	}
}

/*<Codenesium>
    <Hash>cbfb74ebb6c4550e2ac84031ce610e4b</Hash>
</Codenesium>*/