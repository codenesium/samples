using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractSpaceFeatureMapper
        {
                public virtual BOSpaceFeature MapModelToBO(
                        int id,
                        ApiSpaceFeatureRequestModel model
                        )
                {
                        BOSpaceFeature boSpaceFeature = new BOSpaceFeature();
                        boSpaceFeature.SetProperties(
                                id,
                                model.Name,
                                model.StudioId);
                        return boSpaceFeature;
                }

                public virtual ApiSpaceFeatureResponseModel MapBOToModel(
                        BOSpaceFeature boSpaceFeature)
                {
                        var model = new ApiSpaceFeatureResponseModel();

                        model.SetProperties(boSpaceFeature.Id, boSpaceFeature.Name, boSpaceFeature.StudioId);

                        return model;
                }

                public virtual List<ApiSpaceFeatureResponseModel> MapBOToModel(
                        List<BOSpaceFeature> items)
                {
                        List<ApiSpaceFeatureResponseModel> response = new List<ApiSpaceFeatureResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>6050a33cc3a6141dd9cbd2ee00073e77</Hash>
</Codenesium>*/