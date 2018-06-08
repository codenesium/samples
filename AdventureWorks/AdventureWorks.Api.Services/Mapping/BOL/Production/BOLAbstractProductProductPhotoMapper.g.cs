using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductProductPhotoMapper
        {
                public virtual BOProductProductPhoto MapModelToBO(
                        int productID,
                        ApiProductProductPhotoRequestModel model
                        )
                {
                        BOProductProductPhoto boProductProductPhoto = new BOProductProductPhoto();

                        boProductProductPhoto.SetProperties(
                                productID,
                                model.ModifiedDate,
                                model.Primary,
                                model.ProductPhotoID);
                        return boProductProductPhoto;
                }

                public virtual ApiProductProductPhotoResponseModel MapBOToModel(
                        BOProductProductPhoto boProductProductPhoto)
                {
                        var model = new ApiProductProductPhotoResponseModel();

                        model.SetProperties(boProductProductPhoto.ModifiedDate, boProductProductPhoto.Primary, boProductProductPhoto.ProductID, boProductProductPhoto.ProductPhotoID);

                        return model;
                }

                public virtual List<ApiProductProductPhotoResponseModel> MapBOToModel(
                        List<BOProductProductPhoto> items)
                {
                        List<ApiProductProductPhotoResponseModel> response = new List<ApiProductProductPhotoResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>634f6d24609cd879bf4b9268eedf4740</Hash>
</Codenesium>*/