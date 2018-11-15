using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiCustomerClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiCustomerClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			string accountNumber,
			DateTime modifiedDate,
			int? personID,
			Guid rowguid,
			int? storeID,
			int? territoryID)
		{
			this.AccountNumber = accountNumber;
			this.ModifiedDate = modifiedDate;
			this.PersonID = personID;
			this.Rowguid = rowguid;
			this.StoreID = storeID;
			this.TerritoryID = territoryID;
		}

		[JsonProperty]
		public string AccountNumber { get; private set; } = default(string);

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int? PersonID { get; private set; } = default(int);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>23146b10622ff240e6423411eb4d3378</Hash>
</Codenesium>*/