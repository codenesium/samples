using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>618d3f8c0c52853dfc8079537fb9d1fc</Hash>
</Codenesium>*/