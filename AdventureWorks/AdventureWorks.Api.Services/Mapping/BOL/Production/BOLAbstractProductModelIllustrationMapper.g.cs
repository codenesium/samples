using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public abstract class BOLAbstractProductModelIllustrationMapper
        {
                public virtual BOProductModelIllustration MapModelToBO(
                        int productModelID,
                        ApiProductModelIllustrationRequestModel model
                        )
                {
                        BOProductModelIllustration boProductModelIllustration = new BOProductModelIllustration();
                        boProductModelIllustration.SetProperties(
                                productModelID,
                                model.IllustrationID,
                                model.ModifiedDate);
                        return boProductModelIllustration;
                }

                public virtual ApiProductModelIllustrationResponseModel MapBOToModel(
                        BOProductModelIllustration boProductModelIllustration)
                {
                        var model = new ApiProductModelIllustrationResponseModel();

                        model.SetProperties(boProductModelIllustration.IllustrationID, boProductModelIllustration.ModifiedDate, boProductModelIllustration.ProductModelID);

                        return model;
                }

                public virtual List<ApiProductModelIllustrationResponseModel> MapBOToModel(
                        List<BOProductModelIllustration> items)
                {
                        List<ApiProductModelIllustrationResponseModel> response = new List<ApiProductModelIllustrationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7aa505883ee4a40c5ae8149a33791e66</Hash>
</Codenesium>*/