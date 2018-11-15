using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCustomerClientResponseModel : AbstractApiClientResponseModel
	{
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

			this.StoreIDEntity = nameof(ApiResponse.Stores);
			this.TerritoryIDEntity = nameof(ApiResponse.SalesTerritories);
		}

		[JsonProperty]
		public string AccountNumber { get; private set; }

		[JsonProperty]
		public int CustomerID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int? PersonID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public string StoreIDEntity { get; set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>ddd760f3699992d301ef0cd1971b2ea0</Hash>
</Codenesium>*/