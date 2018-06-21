using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductProductPhoto", Schema="Production")]
        public partial class ProductProductPhoto : AbstractEntity
        {
                public ProductProductPhoto()
                {
                }

                public void SetProperties(
                        DateTime modifiedDate,
                        bool primary,
                        int productID,
                        int productPhotoID)
                {
                        this.ModifiedDate = modifiedDate;
                        this.Primary = primary;
                        this.ProductID = productID;
                        this.ProductPhotoID = productPhotoID;
                }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Column("Primary")]
                public bool Primary { get; private set; }

                [Key]
                [Column("ProductID")]
                public int ProductID { get; private set; }

                [Column("ProductPhotoID")]
                public int ProductPhotoID { get; private set; }
        }
}

/*<Codenesium>
    <Hash>88f5eb3ca582477904bccd7b343ae4db</Hash>
</Codenesium>*/