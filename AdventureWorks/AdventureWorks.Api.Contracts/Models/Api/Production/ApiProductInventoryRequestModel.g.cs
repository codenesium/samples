using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductInventoryRequestModel : AbstractApiRequestModel
	{
		public ApiProductInventoryRequestModel()
			: base()
		{
		}

		public virtual void SetProperties(
			int bin,
			short locationID,
			DateTime modifiedDate,
			short quantity,
			Guid rowguid,
			string shelf)
		{
			this.Bin = bin;
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.Shelf = shelf;
		}

		[Required]
		[JsonProperty]
		public int Bin { get; private set; }

		[Required]
		[JsonProperty]
		public short LocationID { get; private set; }

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; }

		[Required]
		[JsonProperty]
		public short Quantity { get; private set; }

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; }

		[Required]
		[JsonProperty]
		public string Shelf { get; private set; }
	}
}

/*<Codenesium>
    <Hash>89c1b99f7c6d16f3797043f4f3245fad</Hash>
</Codenesium>*/