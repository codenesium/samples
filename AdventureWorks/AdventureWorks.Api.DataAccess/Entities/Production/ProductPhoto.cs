using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdventureWorksNS.Api.DataAccess
{
        [Table("ProductPhoto", Schema="Production")]
        public partial class ProductPhoto : AbstractEntity
        {
                public ProductPhoto()
                {
                }

                public void SetProperties(
                        byte[] largePhoto,
                        string largePhotoFileName,
                        DateTime modifiedDate,
                        int productPhotoID,
                        byte[] thumbNailPhoto,
                        string thumbnailPhotoFileName)
                {
                        this.LargePhoto = largePhoto;
                        this.LargePhotoFileName = largePhotoFileName;
                        this.ModifiedDate = modifiedDate;
                        this.ProductPhotoID = productPhotoID;
                        this.ThumbNailPhoto = thumbNailPhoto;
                        this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
                }

                [Column("LargePhoto")]
                public byte[] LargePhoto { get; private set; }

                [Column("LargePhotoFileName")]
                public string LargePhotoFileName { get; private set; }

                [Column("ModifiedDate")]
                public DateTime ModifiedDate { get; private set; }

                [Key]
                [Column("ProductPhotoID")]
                public int ProductPhotoID { get; private set; }

                [Column("ThumbNailPhoto")]
                public byte[] ThumbNailPhoto { get; private set; }

                [Column("ThumbnailPhotoFileName")]
                public string ThumbnailPhotoFileName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>499d6f6a08188f813246a343e2047c6b</Hash>
</Codenesium>*/