using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiSalesTerritoryHistoryRequestModel : AbstractApiRequestModel
	{
		public ApiSalesTerritoryHistoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime? endDate,
			DateTime modifiedDate,
			Guid rowguid,
			DateTime startDate,
			int territoryID)
		{
			this.EndDate = endDate;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.StartDate = startDate;
			this.TerritoryID = territoryID;
		}

		[JsonProperty]
		public DateTime? EndDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public DateTime StartDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public int TerritoryID { get; private set; } = default(int);
	}
}

/*<Codenesium>
    <Hash>d209862b32b173d40f28d863775bffdd</Hash>
</Codenesium>*/