using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
	[Table("SpecialOffer", Schema="Sales")]
	public partial class SpecialOffer : AbstractEntity
	{
		public SpecialOffer()
		{
		}

		public virtual void SetProperties(
			string category,
			string description,
			decimal discountPct,
			DateTime endDate,
			int? maxQty,
			int minQty,
			DateTime modifiedDate,
			Guid rowguid,
			int specialOfferID,
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

		[MaxLength(50)]
		[Column("Category")]
		public virtual string Category { get; private set; }

		[MaxLength(255)]
		[Column("Description")]
		public virtual string Description { get; private set; }

		[Column("DiscountPct")]
		public virtual decimal DiscountPct { get; private set; }

		[Column("EndDate")]
		public virtual DateTime EndDate { get; private set; }

		[Column("MaxQty")]
		public virtual int? MaxQty { get; private set; }

		[Column("MinQty")]
		public virtual int MinQty { get; private set; }

		[Column("ModifiedDate")]
		public virtual DateTime ModifiedDate { get; private set; }

		[Column("rowguid")]
		public virtual Guid Rowguid { get; private set; }

		[Key]
		[Column("SpecialOfferID")]
		public virtual int SpecialOfferID { get; private set; }

		[Column("StartDate")]
		public virtual DateTime StartDate { get; private set; }

		[MaxLength(50)]
		[Column("Type")]
		public virtual string Type { get; private set; }
	}
}

/*<Codenesium>
    <Hash>a5f240d987ee7dffae3b75bbf6e73d48</Hash>
</Codenesium>*/