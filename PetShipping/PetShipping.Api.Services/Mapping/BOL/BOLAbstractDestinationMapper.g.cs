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

                        model.SetProperties(boDestination.Id, boDestination.CountryId, boDestination.Name, boDestination.Order);

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
    <Hash>6e8161bb7b2fc2df37bb19547ffa6fbf</Hash>
</Codenesium>*/