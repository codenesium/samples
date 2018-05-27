using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace AdventureWorksNS.Api.Contracts
{
	public partial class DTOSpecialOffer: AbstractDTO
	{
		public DTOSpecialOffer() : base()
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
	}
}

/*<Codenesium>
    <Hash>26b534fab833ea5dde011358d1d07965</Hash>
</Codenesium>*/