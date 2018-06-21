using Codenesium.DataConversionExtensions;
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

                public void SetProperties(
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
                                return this.largePhoto.IsEmptyOrZeroOrNull() ? null : this.largePhoto;
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
                                return this.largePhotoFileName.IsEmptyOrZeroOrNull() ? null : this.largePhotoFileName;
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
                                return this.thumbNailPhoto.IsEmptyOrZeroOrNull() ? null : this.thumbNailPhoto;
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
                                return this.thumbnailPhotoFileName.IsEmptyOrZeroOrNull() ? null : this.thumbnailPhotoFileName;
                        }

                        set
                        {
                                this.thumbnailPhotoFileName = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>d06a10d5127e9524f487902a3a3dedbd</Hash>
</Codenesium>*/