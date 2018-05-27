using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace AdventureWorksNS.Api.Contracts
{
	public partial class ApiProductInventoryResponseModel: AbstractApiResponseModel
	{
		public ApiProductInventoryResponseModel() : base()
		{}

		public void SetProperties(
			int bin,
			short locationID,
			DateTime modifiedDate,
			int productID,
			short quantity,
			Guid rowguid,
			string shelf)
		{
			this.Bin = bin.ToInt();
			this.LocationID = locationID;
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.ProductID = productID.ToInt();
			this.Quantity = quantity;
			this.Rowguid = rowguid.ToGuid();
			this.Shelf = shelf;
		}

		public int Bin { get; set; }
		public short LocationID { get; set; }
		public DateTime ModifiedDate { get; set; }
		public int ProductID { get; set; }
		public short Quantity { get; set; }
		public Guid Rowguid { get; set; }
		public string Shelf { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeBinValue { get; set; } = true;

		public bool ShouldSerializeBin()
		{
			return this.ShouldSerializeBinValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue { get; set; } = true;

		public bool ShouldSerializeQuantity()
		{
			return this.ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShelfValue { get; set; } = true;

		public bool ShouldSerializeShelf()
		{
			return this.ShouldSerializeShelfValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeBinValue = false;
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeShelfValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>7be77667eec97ce30f0af301579a7f5d</Hash>
</Codenesium>*/