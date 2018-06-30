using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLHandlerPipelineStepMapper
        {
                BOHandlerPipelineStep MapModelToBO(
                        int id,
                        ApiHandlerPipelineStepRequestModel model);

                ApiHandlerPipelineStepResponseModel MapBOToModel(
                        BOHandlerPipelineStep boHandlerPipelineStep);

                List<ApiHandlerPipelineStepResponseModel> MapBOToModel(
                        List<BOHandlerPipelineStep> items);
        }
}

/*<Codenesium>
    <Hash>289c2ca6eb2d892c96db4e718f05567c</Hash>
</Codenesium>*/