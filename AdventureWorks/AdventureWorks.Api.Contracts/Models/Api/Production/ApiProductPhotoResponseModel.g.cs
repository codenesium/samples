using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Contracts
{
        public class ApiProductPhotoResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
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

                public byte[] LargePhoto { get; private set; }

                public string LargePhotoFileName { get; private set; }

                public DateTime ModifiedDate { get; private set; }

                public int ProductPhotoID { get; private set; }

                public byte[] ThumbNailPhoto { get; private set; }

                public string ThumbnailPhotoFileName { get; private set; }

                [JsonIgnore]
                public bool ShouldSerializeLargePhotoValue { get; set; } = true;

                public bool ShouldSerializeLargePhoto()
                {
                        return this.ShouldSerializeLargePhotoValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeLargePhotoFileNameValue { get; set; } = true;

                public bool ShouldSerializeLargePhotoFileName()
                {
                        return this.ShouldSerializeLargePhotoFileNameValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeModifiedDateValue { get; set; } = true;

                public bool ShouldSerializeModifiedDate()
                {
                        return this.ShouldSerializeModifiedDateValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeProductPhotoIDValue { get; set; } = true;

                public bool ShouldSerializeProductPhotoID()
                {
                        return this.ShouldSerializeProductPhotoIDValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeThumbNailPhotoValue { get; set; } = true;

                public bool ShouldSerializeThumbNailPhoto()
                {
                        return this.ShouldSerializeThumbNailPhotoValue;
                }

                [JsonIgnore]
                public bool ShouldSerializeThumbnailPhotoFileNameValue { get; set; } = true;

                public bool ShouldSerializeThumbnailPhotoFileName()
                {
                        return this.ShouldSerializeThumbnailPhotoFileNameValue;
                }

                public virtual void DisableAllFields()
                {
                        this.ShouldSerializeLargePhotoValue = false;
                        this.ShouldSerializeLargePhotoFileNameValue = false;
                        this.ShouldSerializeModifiedDateValue = false;
                        this.ShouldSerializeProductPhotoIDValue = false;
                        this.ShouldSerializeThumbNailPhotoValue = false;
                        this.ShouldSerializeThumbnailPhotoFileNameValue = false;
                }
        }
}

/*<Codenesium>
    <Hash>1665e94f625b7c7f93cdd39a69557fef</Hash>
</Codenesium>*/