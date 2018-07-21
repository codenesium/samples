using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductModelIllustration", Schema="Production")]
        public partial class ProductModelIllustration : AbstractEntity
        {
                public ProductModelIllustration()
                {
                }

                public virtual void SetProperties(
                        int illustrationID,
                        DateTime modifiedDate,
                        int productModelID)
                {
                        this.IllustrationID = illustrationID;
                        this.ModifiedDate = modifiedDate;
                        this.ProductModelID = productModelID;
                }

                [Column("IllustrationID")]
                public int IllustrationID { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductModelID")]
                public int ProductModelID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>7d880e0c1e450b0916d3e406004c4ec5</Hash>
</Codenesium>*/