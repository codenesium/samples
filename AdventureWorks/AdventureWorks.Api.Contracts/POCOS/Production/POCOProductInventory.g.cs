using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductInventory
	{
		public POCOProductInventory()
		{}

		public POCOProductInventory(
			int productID,
			short locationID,
			string shelf,
			int bin,
			short quantity,
			Guid rowguid,
			DateTime modifiedDate)
		{
			this.Shelf = shelf.ToString();
			this.Bin = bin.ToInt();
			this.Quantity = quantity;
			this.Rowguid = rowguid.ToGuid();
			this.ModifiedDate = modifiedDate.ToDateTime();

			this.ProductID = new ReferenceEntity<int>(productID,
			                                          nameof(ApiResponse.Products));
			this.LocationID = new ReferenceEntity<short>(locationID,
			                                             nameof(ApiResponse.Locations));
		}

		public ReferenceEntity<int> ProductID { get; set; }
		public ReferenceEntity<short> LocationID { get; set; }
		public string Shelf { get; set; }
		public int Bin { get; set; }
		public short Quantity { get; set; }
		public Guid Rowguid { get; set; }
		public DateTime ModifiedDate { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue { get; set; } = true;

		public bool ShouldSerializeProductID()
		{
			return this.ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue { get; set; } = true;

		public bool ShouldSerializeLocationID()
		{
			return this.ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShelfValue { get; set; } = true;

		public bool ShouldSerializeShelf()
		{
			return this.ShouldSerializeShelfValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBinValue { get; set; } = true;

		public bool ShouldSerializeBin()
		{
			return this.ShouldSerializeBinValue;
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
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeProductIDValue = false;
			this.ShouldSerializeLocationIDValue = false;
			this.ShouldSerializeShelfValue = false;
			this.ShouldSerializeBinValue = false;
			this.ShouldSerializeQuantityValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>3f50bca2e344e7505304f8fb59e0a6c8</Hash>
</Codenesium>*/