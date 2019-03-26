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
			int specialOfferID,
			string category,
			string description,
			decimal discountPct,
			DateTime endDate,
			int? maxQty,
			int minQty,
			DateTime modifiedDate,
			string reservedType,
			Guid rowguid,
			DateTime startDate)
		{
			this.SpecialOfferID = specialOfferID;
			this.Category = category;
			this.Description = description;
			this.DiscountPct = discountPct;
			this.EndDate = endDate;
			this.MaxQty = maxQty;
			this.MinQty = minQty;
			this.ModifiedDate = modifiedDate;
			this.ReservedType = reservedType;
			this.Rowguid = rowguid;
			this.StartDate = startDate;
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
		public virtual string ReservedType { get; private set; }
	}
}

/*<Codenesium>
    <Hash>d3d93f75beb7fc89e2080d8ef610bda4</Hash>
</Codenesium>*/