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
		public int Bin { get; private set; } = default(int);

		[Required]
		[JsonProperty]
		public short LocationID { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public DateTime ModifiedDate { get; private set; } = default(DateTime);

		[Required]
		[JsonProperty]
		public short Quantity { get; private set; } = default(short);

		[Required]
		[JsonProperty]
		public Guid Rowguid { get; private set; } = default(Guid);

		[Required]
		[JsonProperty]
		public string Shelf { get; private set; } = default(string);
	}
}

/*<Codenesium>
    <Hash>db689c5fbbef3949f9fc79ce4c859d82</Hash>
</Codenesium>*/