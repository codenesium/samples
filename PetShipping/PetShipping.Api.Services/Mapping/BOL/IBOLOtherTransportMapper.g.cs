using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>2ddd80fea49225be792d693ca8a226bb</Hash>
</Codenesium>*/