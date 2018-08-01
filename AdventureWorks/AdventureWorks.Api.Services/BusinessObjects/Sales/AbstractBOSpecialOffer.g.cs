using Codenesium.DataConversionExtensions;
using System;

namespace AdventureWorksNS.Api.Services
{
	public abstract class AbstractBOSpecialOffer : AbstractBusinessObject
	{
		public AbstractBOSpecialOffer()
			: base()
		{
		}

		public virtual void SetProperties(int specialOfferID,
		                                  string category,
		                                  string description,
		                                  decimal discountPct,
		                                  DateTime endDate,
		                                  int? maxQty,
		                                  int minQty,
		                                  DateTime modifiedDate,
		                                  Guid rowguid,
		                                  DateTime startDate,
		                                  string type)
		{
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct;
			this.EndDate = endDate;
			this.MaxQty = maxQty;
			this.MinQty = minQty;
			this.ModifiedDate = modifiedDate;
			this.Rowguid = rowguid;
			this.SpecialOfferID = specialOfferID;
			this.StartDate = startDate;
			this.Type = type;
		}

		public string Category { get; private set; }

		public string Description { get; private set; }

		public decimal DiscountPct { get; private set; }

		public DateTime EndDate { get; private set; }

		public int? MaxQty { get; private set; }

		public int MinQty { get; private set; }

		public DateTime ModifiedDate { get; private set; }

		public Guid Rowguid { get; private set; }

		public int SpecialOfferID { get; private set; }

		public DateTime StartDate { get; private set; }

		public string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8311f0c0c9fbd6f2260faf760e26aa7c</Hash>
</Codenesium>*/