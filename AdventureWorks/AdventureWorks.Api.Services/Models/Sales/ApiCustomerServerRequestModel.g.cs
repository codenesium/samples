using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiCustomerServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiCustomerServerRequestModel()
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
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public int? PersonID { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public int? StoreID { get; private set; }

		[JsonProperty]
		public int? TerritoryID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>73180e0d0349105f9ee59d81c10a2ce4</Hash>
</Codenesium>*/