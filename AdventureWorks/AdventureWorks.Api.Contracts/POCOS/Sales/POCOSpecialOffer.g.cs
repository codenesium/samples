using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class POCOSpecialOffer: AbstractPOCO
	{
		public POCOSpecialOffer() : base()
		{}

		public POCOSpecialOffer(
			string category,
			string description,
			decimal discountPct,
			DateTime endDate,
			Nullable<int> maxQty,
			int minQty,
			DateTime modifiedDate,
			Guid rowguid,
			int specialOfferID,
			DateTime startDate,
			string type)
		{
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct.ToDecimal();
			this.EndDate = endDate.ToDateTime();
			this.MaxQty = maxQty.ToNullableInt();
			this.MinQty = minQty.ToInt();
			this.ModifiedDate = modifiedDate.ToDateTime();
			this.Rowguid = rowguid.ToGuid();
			this.SpecialOfferID = specialOfferID.ToInt();
			this.StartDate = startDate.ToDateTime();
			this.Type = type;
		}

		public string Category { get; set; }
		public string Description { get; set; }
		public decimal DiscountPct { get; set; }
		public DateTime EndDate { get; set; }
		public Nullable<int> MaxQty { get; set; }
		public int MinQty { get; set; }
		public DateTime ModifiedDate { get; set; }
		public Guid Rowguid { get; set; }
		public int SpecialOfferID { get; set; }
		public DateTime StartDate { get; set; }
		public string Type { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeCategoryValue { get; set; } = true;

		public bool ShouldSerializeCategory()
		{
			return this.ShouldSerializeCategoryValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDescriptionValue { get; set; } = true;

		public bool ShouldSerializeDescription()
		{
			return this.ShouldSerializeDescriptionValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDiscountPctValue { get; set; } = true;

		public bool ShouldSerializeDiscountPct()
		{
			return this.ShouldSerializeDiscountPctValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEndDateValue { get; set; } = true;

		public bool ShouldSerializeEndDate()
		{
			return this.ShouldSerializeEndDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMaxQtyValue { get; set; } = true;

		public bool ShouldSerializeMaxQty()
		{
			return this.ShouldSerializeMaxQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeMinQtyValue { get; set; } = true;

		public bool ShouldSerializeMinQty()
		{
			return this.ShouldSerializeMinQtyValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeModifiedDateValue { get; set; } = true;

		public bool ShouldSerializeModifiedDate()
		{
			return this.ShouldSerializeModifiedDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeRowguidValue { get; set; } = true;

		public bool ShouldSerializeRowguid()
		{
			return this.ShouldSerializeRowguidValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeSpecialOfferIDValue { get; set; } = true;

		public bool ShouldSerializeSpecialOfferID()
		{
			return this.ShouldSerializeSpecialOfferIDValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStartDateValue { get; set; } = true;

		public bool ShouldSerializeStartDate()
		{
			return this.ShouldSerializeStartDateValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTypeValue { get; set; } = true;

		public bool ShouldSerializeType()
		{
			return this.ShouldSerializeTypeValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeCategoryValue = false;
			this.ShouldSerializeDescriptionValue = false;
			this.ShouldSerializeDiscountPctValue = false;
			this.ShouldSerializeEndDateValue = false;
			this.ShouldSerializeMaxQtyValue = false;
			this.ShouldSerializeMinQtyValue = false;
			this.ShouldSerializeModifiedDateValue = false;
			this.ShouldSerializeRowguidValue = false;
			this.ShouldSerializeSpecialOfferIDValue = false;
			this.ShouldSerializeStartDateValue = false;
			this.ShouldSerializeTypeValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>48fb8be799b79dfb242a89b0c580d7a4</Hash>
</Codenesium>*/