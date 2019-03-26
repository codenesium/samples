using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiShipMethodServerResponseModel : AbstractApiServerResponseModel
	{
		public virtual void SetProperties(
			int shipMethodID,
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			decimal shipRate)
		{
			this.ShipMethodID = shipMethodID;
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ShipBase = shipBase;
			this.ShipRate = shipRate;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[JsonProperty]
		public string Name { get; private set; }

		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[JsonProperty]
		public decimal ShipBase { get; private set; }

		[JsonProperty]
		public int ShipMethodID { get; private set; }

		[JsonProperty]
		public decimal ShipRate { get; private set; }
	}
}

/*<Codenesium>
    <Hash>5fd3507eb2270b6ac89fbbeb0a56b7b0</Hash>
</Codenesium>*/