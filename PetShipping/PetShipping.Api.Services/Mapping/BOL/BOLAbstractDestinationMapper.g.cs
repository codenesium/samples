using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>208b1fbb59b0fa9b513d495337c00010</Hash>
</Codenesium>*/