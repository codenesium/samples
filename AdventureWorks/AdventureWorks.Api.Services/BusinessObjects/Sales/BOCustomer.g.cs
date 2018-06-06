using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOCustomer: AbstractBusinessObject
	{
		public BOCustomer() : base()
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

		public string AccountNumber { get; private set; }
		public int CustomerID { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Nullable<int> PersonID { get; private set; }
		public Guid Rowguid { get; private set; }
		public Nullable<int> StoreID { get; private set; }
		public Nullable<int> TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>23e88cca1aba0f03dd75f3191febc46b</Hash>
</Codenesium>*/