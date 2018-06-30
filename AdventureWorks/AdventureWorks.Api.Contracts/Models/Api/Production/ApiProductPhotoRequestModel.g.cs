using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public partial class ApiProductPhotoRequestModel : AbstractApiRequestModel
        {
                public ApiProductPhotoRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        byte[] largePhoto,
                        string largePhotoFileName,
                        DateTime modifiedDate,
                        byte[] thumbNailPhoto,
                        string thumbnailPhotoFileName)
                {
                        this.LargePhoto = largePhoto;
                        this.LargePhotoFileName = largePhotoFileName;
                        this.ModifiedDate = modifiedDate;
                        this.ThumbNailPhoto = thumbNailPhoto;
                        this.ThumbnailPhotoFileName = thumbnailPhotoFileName;
                }

                private byte[] largePhoto;

                public byte[] LargePhoto
                {
                        get
                        {
                                return this.largePhoto;
                        }

                        set
                        {
                                this.largePhoto = value;
                        }
                }

                private string largePhotoFileName;

                public string LargePhotoFileName
                {
                        get
                        {
                                return this.largePhotoFileName;
                        }

                        set
                        {
                                this.largePhotoFileName = value;
                        }
                }

                private DateTime modifiedDate;

                [Required]
                public DateTime ModifiedDate
                {
                        get
                        {
                                return this.modifiedDate;
                        }

                        set
                        {
                                this.modifiedDate = value;
                        }
                }

                private byte[] thumbNailPhoto;

                public byte[] ThumbNailPhoto
                {
                        get
                        {
                                return this.thumbNailPhoto;
                        }

                        set
                        {
                                this.thumbNailPhoto = value;
                        }
                }

                private string thumbnailPhotoFileName;

                public string ThumbnailPhotoFileName
                {
                        get
                        {
                                return this.thumbnailPhotoFileName;
                        }

                        set
                        {
                                this.thumbnailPhotoFileName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d83defbe5438bb79b14c784c0bebddf0</Hash>
</Codenesium>*/