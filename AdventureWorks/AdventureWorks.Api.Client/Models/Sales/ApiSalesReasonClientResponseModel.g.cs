using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiSalesReasonClientResponseModel : AbstractApiClientResponseModel
	{
		public virtual void SetProperties(
			int salesReasonID,
			DateTime modifiedDate,
			string name,
			string reasonType)
		{
			this.SalesReasonID = salesReasonID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.ReasonType = reasonType;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public string ReasonType { get; private set; }

		[JsonProperty]
		public int SalesReasonID { get; private set; }
	}
}

/*<Codenesium>
    <Hash>73f89907c3d6b9c9d0434dfa07ca0f2f</Hash>
</Codenesium>*/