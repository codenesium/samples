using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStatusMapper
        {
                BOPipelineStatus MapModelToBO(
                        int id,
                        ApiPipelineStatusRequestModel model);

                ApiPipelineStatusResponseModel MapBOToModel(
                        BOPipelineStatus boPipelineStatus);

                List<ApiPipelineStatusResponseModel> MapBOToModel(
                        List<BOPipelineStatus> items);
        }
}

/*<Codenesium>
    <Hash>71838c3ab0cb3326cfe288d0bf7001e5</Hash>
</Codenesium>*/