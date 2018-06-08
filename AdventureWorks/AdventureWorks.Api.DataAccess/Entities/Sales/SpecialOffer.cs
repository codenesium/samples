using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SpecialOffer", Schema="Sales")]
        public partial class SpecialOffer: AbstractEntity
        {
                public SpecialOffer()
                {
                }

                public void SetProperties(
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

                [Column("Category", TypeName="nvarchar(50)")]
                public string Category { get; private set; }

                [Column("Description", TypeName="nvarchar(255)")]
                public string Description { get; private set; }

                [Column("DiscountPct", TypeName="smallmoney")]
                public decimal DiscountPct { get; private set; }

                [Column("EndDate", TypeName="datetime")]
                public DateTime EndDate { get; private set; }

                [Column("MaxQty", TypeName="int")]
                public Nullable<int> MaxQty { get; private set; }

                [Column("MinQty", TypeName="int")]
                public int MinQty { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SpecialOfferID", TypeName="int")]
                public int SpecialOfferID { get; private set; }

                [Column("StartDate", TypeName="datetime")]
                public DateTime StartDate { get; private set; }

                [Column("Type", TypeName="nvarchar(50)")]
                public string Type { get; private set; }
        }
}

/*<Codenesium>
    <Hash>dd1a9b1168ffad86c65f3e6a3898f599</Hash>
</Codenesium>*/