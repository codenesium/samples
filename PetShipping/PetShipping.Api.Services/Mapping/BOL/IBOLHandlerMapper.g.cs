using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

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
    <Hash>22bfb353075a87dcd184d7bd3a1c9feb</Hash>
</Codenesium>*/