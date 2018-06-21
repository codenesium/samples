using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractStudioMapper
        {
                public virtual BOStudio MapModelToBO(
                        int id,
                        ApiStudioRequestModel model
                        )
                {
                        BOStudio boStudio = new BOStudio();
                        boStudio.SetProperties(
                                id,
                                model.Address1,
                                model.Address2,
                                model.City,
                                model.Name,
                                model.StateId,
                                model.Website,
                                model.Zip);
                        return boStudio;
                }

                public virtual ApiStudioResponseModel MapBOToModel(
                        BOStudio boStudio)
                {
                        var model = new ApiStudioResponseModel();

                        model.SetProperties(boStudio.Address1, boStudio.Address2, boStudio.City, boStudio.Id, boStudio.Name, boStudio.StateId, boStudio.Website, boStudio.Zip);

                        return model;
                }

                public virtual List<ApiStudioResponseModel> MapBOToModel(
                        List<BOStudio> items)
                {
                        List<ApiStudioResponseModel> response = new List<ApiStudioResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a8752bb4e5186cf39060792e4af1d387</Hash>
</Codenesium>*/