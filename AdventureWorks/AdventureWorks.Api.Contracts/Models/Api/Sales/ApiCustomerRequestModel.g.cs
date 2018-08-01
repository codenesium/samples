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
		public string AccountNumber { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public int? PersonID { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>f7dfb5407e2b63ae857cd3e98d861d40</Hash>
</Codenesium>*/