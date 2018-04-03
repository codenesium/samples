using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOProductInventory
	{
		public POCOProductInventory()
		{}

		public POCOProductInventory(int productID,
		                            short locationID,
		                            string shelf,
		                            int bin,
		                            short quantity,
		                            Guid rowguid,
		                            DateTime modifiedDate)
		{
			this.ProductID = productID.ToInt();
			this.LocationID = locationID;
			this.Shelf = shelf;
			this.Bin = bin;
			this.Quantity = quantity;
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int ProductID {get; set;}
		public short LocationID {get; set;}
		public string Shelf {get; set;}
		public int Bin {get; set;}
		public short Quantity {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeProductIDValue {get; set;} = true;

		public bool ShouldSerializeProductID()
		{
			return ShouldSerializeProductIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLocationIDValue {get; set;} = true;

		public bool ShouldSerializeLocationID()
		{
			return ShouldSerializeLocationIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeShelfValue {get; set;} = true;

		public bool ShouldSerializeShelf()
		{
			return ShouldSerializeShelfValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeBinValue {get; set;} = true;

		public bool ShouldSerializeBin()
		{
			return ShouldSerializeBinValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeQuantityValue {get; set;} = true;

		public bool ShouldSerializeQuantity()
		{
			return ShouldSerializeQuantityValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue {get; set;} = true;

		public bool ShouldSerializeRowguid()
		{
			return ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue {get; set;} = true;

		public bool ShouldSerializeModifiedDate()
		{
			return ShouldSerializeModifiedDateValue;
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
    <Hash>e6a55540b3426ce41b9cf7118ab978aa</Hash>
</Codenesium>*/