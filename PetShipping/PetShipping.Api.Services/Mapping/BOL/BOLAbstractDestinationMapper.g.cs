using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public abstract class BOLAbstractDestinationMapper
        {
                public virtual BODestination MapModelToBO(
                        int id,
                        ApiDestinationRequestModel model
                        )
                {
                        BODestination boDestination = new BODestination();
                        boDestination.SetProperties(
                                id,
                                model.CountryId,
                                model.Name,
                                model.Order);
                        return boDestination;
                }

                public virtual ApiDestinationResponseModel MapBOToModel(
                        BODestination boDestination)
                {
                        var model = new ApiDestinationResponseModel();

                        model.SetProperties(boDestination.CountryId, boDestination.Id, boDestination.Name, boDestination.Order);

                        return model;
                }

                public virtual List<ApiDestinationResponseModel> MapBOToModel(
                        List<BODestination> items)
                {
                        List<ApiDestinationResponseModel> response = new List<ApiDestinationResponseModel>();

                        items.ForEach(d =>
                        {
                                response.Add(this.MapBOToModel(d));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3d8938e5d9e0fac3784076ad2c294117</Hash>
</Codenesium>*/