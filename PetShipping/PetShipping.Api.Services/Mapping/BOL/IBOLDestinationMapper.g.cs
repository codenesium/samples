using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLDestinationMapper
        {
                BODestination MapModelToBO(
                        int id,
                        ApiDestinationRequestModel model);

                ApiDestinationResponseModel MapBOToModel(
                        BODestination boDestination);

                List<ApiDestinationResponseModel> MapBOToModel(
                        List<BODestination> items);
        }
}

/*<Codenesium>
    <Hash>a45d15af15f310006e23d27d73487881</Hash>
</Codenesium>*/