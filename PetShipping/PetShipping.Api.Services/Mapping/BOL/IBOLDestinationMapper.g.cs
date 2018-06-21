using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ac9c7a50f8793034476d9b676c10a765</Hash>
</Codenesium>*/