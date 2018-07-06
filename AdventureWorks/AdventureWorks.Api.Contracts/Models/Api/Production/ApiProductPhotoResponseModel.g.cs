using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductPhotoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int productPhotoID,
                        byte[] largePhoto,
                        string largePhotoFileName,
                        DateTime modifiedDate,
                        byte[] thumbNailPhoto,
                        string thumbnailPhotoFileName)
                {
                        this.ProductPhotoID = productPhotoID;
                        this.LargePhoto = largePhoto;
                        this.LargePhotoFileName = largePhotoFileName;
                        this.ModifiedDate = modifiedDate;
                        this.ThumbNailPhoto = thumbNailPhoto;
                        this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
                }

                public byte[] LargePhoto { get; private set; }

                public string LargePhotoFileName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductPhotoID { get; private set; }

                public byte[] ThumbNailPhoto { get; private set; }

                public string ThumbnailPhotoFileName { get; private set; }
        }
}

/*<Codenesium>
    <Hash>4124a6b4ac9cdd46fe1b76edfe6ddb99</Hash>
</Codenesium>*/