using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLAirTransportMapper
        {
                BOAirTransport MapModelToBO(
                        int airlineId,
                        ApiAirTransportRequestModel model);

                ApiAirTransportResponseModel MapBOToModel(
                        BOAirTransport boAirTransport);

                List<ApiAirTransportResponseModel> MapBOToModel(
                        List<BOAirTransport> items);
        }
}

/*<Codenesium>
    <Hash>725cdf7dbf9e92de351c2689b39ec39e</Hash>
</Codenesium>*/