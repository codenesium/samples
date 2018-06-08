using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLOtherTransportMapper
        {
                BOOtherTransport MapModelToBO(
                        int id,
                        ApiOtherTransportRequestModel model);

                ApiOtherTransportResponseModel MapBOToModel(
                        BOOtherTransport boOtherTransport);

                List<ApiOtherTransportResponseModel> MapBOToModel(
                        List<BOOtherTransport> items);
        }
}

/*<Codenesium>
    <Hash>2d1762c54dbcb0d693f5744f69505cb9</Hash>
</Codenesium>*/