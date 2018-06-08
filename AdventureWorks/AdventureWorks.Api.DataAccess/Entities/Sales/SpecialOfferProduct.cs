using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("SpecialOfferProduct", Schema="Sales")]
        public partial class SpecialOfferProduct: AbstractEntity
        {
                public SpecialOfferProduct()
                {
                }

                public void SetProperties(
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

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Column("ProductID", TypeName="int")]
                public int ProductID { get; private set; }

                [Column("rowguid", TypeName="uniqueidentifier")]
                public Guid Rowguid { get; private set; }

                [Key]
                [Column("SpecialOfferID", TypeName="int")]
                public int SpecialOfferID { get; private set; }

                [ForeignKey("SpecialOfferID")]
                public virtual SpecialOffer SpecialOffer { get; set; }
        }
}

/*<Codenesium>
    <Hash>7e3271b07f2acb510549d6c42681a5e1</Hash>
</Codenesium>*/