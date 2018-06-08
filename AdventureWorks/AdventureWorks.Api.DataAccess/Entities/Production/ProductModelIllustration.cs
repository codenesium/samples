using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Codenesium.DataConversionExtensions.AspNetCore;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModelIllustration", Schema="Production")]
        public partial class ProductModelIllustration: AbstractEntity
        {
                public ProductModelIllustration()
                {
                }

                public void SetProperties(
                        int illustrationID,
                        DateTime modifiedDate,
                        int productModelID)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductModelID = productModelID;
                }

                [Column("IllustrationID", TypeName="int")]
                public int IllustrationID { get; private set; }

                [Column("ModifiedDate", TypeName="datetime")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductModelID", TypeName="int")]
                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>0faf5ecc2169158570f06bac7b1e36b5</Hash>
</Codenesium>*/