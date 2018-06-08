using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLHandlerMapper
        {
                BOHandler MapModelToBO(
                        int id,
                        ApiHandlerRequestModel model);

                ApiHandlerResponseModel MapBOToModel(
                        BOHandler boHandler);

                List<ApiHandlerResponseModel> MapBOToModel(
                        List<BOHandler> items);
        }
}

/*<Codenesium>
    <Hash>832021ead8205414d0d1496bc1001498</Hash>
</Codenesium>*/