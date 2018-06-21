using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>dab1b81636130086ea204f48ad344a59</Hash>
</Codenesium>*/