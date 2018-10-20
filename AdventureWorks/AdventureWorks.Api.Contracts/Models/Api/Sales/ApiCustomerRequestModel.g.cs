using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiCustomerRequestModel : AbstractApiRequestModel
	{
		public ApiCustomerRequestModel()
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

		[Required]
		[JsonProperty]
		public string AccountNumber { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[JsonProperty]
		public int? PersonID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? StoreID { get; private set; } = default(int);

		[JsonProperty]
		public int? TerritoryID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>38d13478f10824536e40f36772bac503</Hash>
</Codenesium>*/