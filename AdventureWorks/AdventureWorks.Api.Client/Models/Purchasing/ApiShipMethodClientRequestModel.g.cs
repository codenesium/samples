using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Client
{
	public partial class ApiShipMethodClientRequestModel : AbstractApiClientRequestModel
	{
		public ApiShipMethodClientRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			DateTime modifiedDate,
			string name,
			Guid rowguid,
			decimal shipBase,
			decimal shipRate)
		{
			this.ModifiedDate = modifiedDate;
			this.Name = name;
			this.Rowguid = rowguid;
			this.ShipBase = shipBase;
			this.ShipRate = shipRate;
		}

		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[JsonProperty]
		public decimal ShipBase { get; private set; } = default(decimal);

		[JsonProperty]
		public decimal ShipRate { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>3de737fe94b73814a812ba269412e586</Hash>
</Codenesium>*/