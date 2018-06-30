using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStepStatusMapper
        {
                BOPipelineStepStatus MapModelToBO(
                        int id,
                        ApiPipelineStepStatusRequestModel model);

                ApiPipelineStepStatusResponseModel MapBOToModel(
                        BOPipelineStepStatus boPipelineStepStatus);

                List<ApiPipelineStepStatusResponseModel> MapBOToModel(
                        List<BOPipelineStepStatus> items);
        }
}

/*<Codenesium>
    <Hash>cdbebd39f4af9548d70060c7888d68a6</Hash>
</Codenesium>*/