using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ApiShipMethodServerRequestModel : AbstractApiServerRequestModel
	{
		public ApiShipMethodServerRequestModel()
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

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = SqlDateTime.MinValue.Value;

		[Required]
		[JsonProperty]
		public string Name { get; private set; } = default(string);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public decimal ShipBase { get; private set; } = default(decimal);

		[Required]
		[JsonProperty]
		public decimal ShipRate { get; private set; } = default(decimal);
	}
}

/*<Codenesium>
    <Hash>834be4bcd0e7e239c1116c1f4db16886</Hash>
</Codenesium>*/