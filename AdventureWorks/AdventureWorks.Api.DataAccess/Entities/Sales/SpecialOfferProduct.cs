using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SpecialOfferProduct", Schema="Sales")]
        public partial class SpecialOfferProduct : AbstractEntity
        {
                public SpecialOfferProduct()
                {
                }

                public virtual void SetProperties(
                        DateTime modifiedDate,
                        int productID,
                        Guid rowguid,
                        int specialOfferID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.ProductID = productID;
                        this.Rowguid = rowguid;
                        this.SpecialOfferID = specialOfferID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("rowguid")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SpecialOfferID")]
                public int SpecialOfferID { get; private set; }

                [ForeignKey("SpecialOfferID")]
                public virtual SpecialOffer SpecialOffer { get; set; }
        }
}

/*<Codenesium>
    <Hash>f8add96cbebdcd5d7a7ad61a6410c407</Hash>
</Codenesium>*/