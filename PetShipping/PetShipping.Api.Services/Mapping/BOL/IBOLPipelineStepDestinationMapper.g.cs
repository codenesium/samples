using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStepDestinationMapper
        {
                BOPipelineStepDestination MapModelToBO(
                        int id,
                        ApiPipelineStepDestinationRequestModel model);

                ApiPipelineStepDestinationResponseModel MapBOToModel(
                        BOPipelineStepDestination boPipelineStepDestination);

                List<ApiPipelineStepDestinationResponseModel> MapBOToModel(
                        List<BOPipelineStepDestination> items);
        }
}

/*<Codenesium>
    <Hash>b57faf67029848b72517c60c2236ff2f</Hash>
</Codenesium>*/