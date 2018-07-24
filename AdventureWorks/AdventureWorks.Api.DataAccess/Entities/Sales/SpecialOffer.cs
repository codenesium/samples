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

                [Column("Category")]
                public string Category { get; private set; }

                [Column("Description")]
                public string Description { get; private set; }

                [Column("DiscountPct")]
                public decimal DiscountPct { get; private set; }

                [Column("EndDate")]
                public DateTime EndDate { get; private set; }

                [Column("MaxQty")]
                public int? MaxQty { get; private set; }

                [Column("MinQty")]
                public int MinQty { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Key]
                [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
                [Column("SpecialOfferID")]
                public int SpecialOfferID { get; private set; }

                [Column("StartDate")]
                public DateTime StartDate { get; private set; }

                [Column("Type")]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4fe41a87b96b0bcb753772486fe319d6</Hash>
</Codenesium>*/