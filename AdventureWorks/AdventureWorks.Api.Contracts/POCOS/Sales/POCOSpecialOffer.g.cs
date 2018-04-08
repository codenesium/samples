using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSpecialOffer
	{
		public POCOSpecialOffer()
		{}

		public POCOSpecialOffer(int specialOfferID,
		                        string description,
		                        decimal discountPct,
		                        string type,
		                        string category,
		                        DateTime startDate,
		                        DateTime endDate,
		                        int minQty,
		                        Nullable<int> maxQty,
		                        Guid rowguid,
		                        DateTime modifiedDate)
		{
			this.SpecialOfferID = specialOfferID.ToInt();
			this.Description = description;
			this.DiscountPct = discountPct;
			this.Type = type;
			this.Category = category;
			this.StartDate = startDate.ToDateTime();
			this.EndDate = endDate.ToDateTime();
			this.MinQty = minQty.ToInt();
			this.MaxQty = maxQty.ToNullableInt();
			this.Rowguid = rowguid;
			this.ModifiedDate = modifiedDate.ToDateTime();
		}

		public int SpecialOfferID {get; set;}
		public string Description {get; set;}
		public decimal DiscountPct {get; set;}
		public string Type {get; set;}
		public string Category {get; set;}
		public DateTime StartDate {get; set;}
		public DateTime EndDate {get; set;}
		public int MinQty {get; set;}
		public Nullable<int> MaxQty {get; set;}
		public Guid Rowguid {get; set;}
		public DateTime ModifiedDate {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferIDValue {get; set;} = true;

		public bool ShouldSerializeSpecialOfferID()
		{
			return ShouldSerializeSpecialOfferIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue {get; set;} = true;

		public bool ShouldSerializeDescription()
		{
			return ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiscountPctValue {get; set;} = true;

		public bool ShouldSerializeDiscountPct()
		{
			return ShouldSerializeDiscountPctValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTypeValue {get; set;} = true;

		public bool ShouldSerializeType()
		{
			return ShouldSerializeTypeValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeCategoryValue {get; set;} = true;

		public bool ShouldSerializeCategory()
		{
			return ShouldSerializeCategoryValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue {get; set;} = true;

		public bool ShouldSerializeStartDate()
		{
			return ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue {get; set;} = true;

		public bool ShouldSerializeEndDate()
		{
			return ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMinQtyValue {get; set;} = true;

		public bool ShouldSerializeMinQty()
		{
			return ShouldSerializeMinQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaxQtyValue {get; set;} = true;

		public bool ShouldSerializeMaxQty()
		{
			return ShouldSerializeMaxQtyValue;
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
			this.ShouldSerializeSpecialOfferIDValue = false;
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeDiscountPctValue = false;
			this.ShouldSerializeTypeValue = false;
			this.ShouldSerializeCategoryValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeMinQtyValue = false;
			this.ShouldSerializeMaxQtyValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeModifiedDateValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>8cd1412105a1315ba60abf406342d6df</Hash>
</Codenesium>*/