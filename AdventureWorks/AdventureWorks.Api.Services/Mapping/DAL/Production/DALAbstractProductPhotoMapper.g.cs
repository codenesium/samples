using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractProductPhotoMapper
        {
                public virtual ProductPhoto MapBOToEF(
                        BOProductPhoto bo)
                {
                        ProductPhoto efProductPhoto = new ProductPhoto();

                        efProductPhoto.SetProperties(
                                bo.LargePhoto,
                                bo.LargePhotoFileName,
                                bo.ModifiedDate,
                                bo.ProductPhotoID,
                                bo.ThumbNailPhoto,
                                bo.ThumbnailPhotoFileName);
                        return efProductPhoto;
                }

                public virtual BOProductPhoto MapEFToBO(
                        ProductPhoto ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProductPhoto();

                        bo.SetProperties(
                                ef.ProductPhotoID,
                                ef.LargePhoto,
                                ef.LargePhotoFileName,
                                ef.ModifiedDate,
                                ef.ThumbNailPhoto,
                                ef.ThumbnailPhotoFileName);
                        return bo;
                }

                public virtual List<BOProductPhoto> MapEFToBO(
                        List<ProductPhoto> records)
                {
                        List<BOProductPhoto> response = new List<BOProductPhoto>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>dbc7a4ed2344a2287b15863ff5cbd8e6</Hash>
</Codenesium>*/