using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCustomerResponseModel : AbstractApiResponseModel
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

		[Required]
		[JsonProperty]
		public int? PersonID { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public string StoreIDEntity { get; set; }

		[Required]
		[JsonProperty]
		public int? TerritoryID { get; private set; }

		[JsonProperty]
		public string TerritoryIDEntity { get; set; }
	}
}

/*<Codenesium>
    <Hash>14de57b127685f813d24da81660611a4</Hash>
</Codenesium>*/