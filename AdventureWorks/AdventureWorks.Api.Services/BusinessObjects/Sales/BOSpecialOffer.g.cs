using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Services
{
	public partial class BOSpecialOffer: AbstractBusinessObject
	{
		public BOSpecialOffer() : base()
		{}

		public void SetProperties(int specialOfferID,
		                          string category,
		                          string description,
		                          decimal discountPct,
		                          DateTime endDate,
		                          Nullable<int> maxQty,
		                          int minQty,
		                          DateTime modifiedDate,
		                          Guid rowguid,
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

		public string Category { get; private set; }
		public string Description { get; private set; }
		public decimal DiscountPct { get; private set; }
		public DateTime EndDate { get; private set; }
		public Nullable<int> MaxQty { get; private set; }
		public int MinQty { get; private set; }
		public DateTime ModifiedDate { get; private set; }
		public Guid Rowguid { get; private set; }
		public int SpecialOfferID { get; private set; }
		public DateTime StartDate { get; private set; }
		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8809d4aacfb9aedaf38b121b56a842af</Hash>
</Codenesium>*/