using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCustomerServerResponseModel : AbstractApiServerResponseModel
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
		}

		[JsonProperty]
		public string AccountNumber { get; private set; }

		[JsonProperty]
		public int CustomerID { get; private set; }

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public int? PersonID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public string StoreIDEntity { get; private set; } = RouteConstants.Stores;

		[JsonProperty]
		public ApiStoreServerResponseModel StoreIDNavigation { get; private set; }

		public void SetStoreIDNavigation(ApiStoreServerResponseModel value)
		{
			this.StoreIDNavigation = value;
		}

		[Required]
		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; private set; } = RouteConstants.SalesTerritories;

		[JsonProperty]
		public ApiSalesTerritoryServerResponseModel TerritoryIDNavigation { get; private set; }

		public void SetTerritoryIDNavigation(ApiSalesTerritoryServerResponseModel value)
		{
			this.TerritoryIDNavigation = value;
		}
	}
}

/*<Codenesium>
    <Hash>1566d41913d0ea753aba00f1c430e0e7</Hash>
</Codenesium>*/