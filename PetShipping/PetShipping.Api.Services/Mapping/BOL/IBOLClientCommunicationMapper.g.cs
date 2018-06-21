using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>ece6cd9516752f27653750eeb74d0f1c</Hash>
</Codenesium>*/