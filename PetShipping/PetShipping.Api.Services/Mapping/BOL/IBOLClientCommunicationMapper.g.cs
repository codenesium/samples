using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLClientCommunicationMapper
        {
                BOClientCommunication MapModelToBO(
                        int id,
                        ApiClientCommunicationRequestModel model);

                ApiClientCommunicationResponseModel MapBOToModel(
                        BOClientCommunication boClientCommunication);

                List<ApiClientCommunicationResponseModel> MapBOToModel(
                        List<BOClientCommunication> items);
        }
}

/*<Codenesium>
    <Hash>c546c643502cf3a1008b1e26e5140597</Hash>
</Codenesium>*/