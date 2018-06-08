using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>8ff223fa7d7549e48d83b85bd25a46f1</Hash>
</Codenesium>*/