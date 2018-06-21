using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public abstract class BOLAbstractSpaceMapper
        {
                public virtual BOSpace MapModelToBO(
                        int id,
                        ApiSpaceRequestModel model
                        )
                {
                        BOSpace boSpace = new BOSpace();
                        boSpace.SetProperties(
                                id,
                                model.Description,
                                model.Name,
                                model.StudioId);
                        return boSpace;
                }

                public virtual ApiSpaceResponseModel MapBOToModel(
                        BOSpace boSpace)
                {
                        var model = new ApiSpaceResponseModel();

                        model.SetProperties(boSpace.Description, boSpace.Id, boSpace.Name, boSpace.StudioId);

                        return model;
                }

                public virtual List<ApiSpaceResponseModel> MapBOToModel(
                        List<BOSpace> items)
                {
                        List<ApiSpaceResponseModel> response = new List<ApiSpaceResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>c6b780fb9f1fb4ad0317c2101ad41808</Hash>
</Codenesium>*/