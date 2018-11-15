using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShipMethodClientResponseModel : AbstractApiClientResponseModel
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
    <Hash>0183211b9a7cd7bebead5af31c4c2f6b</Hash>
</Codenesium>*/