using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>04b3246d5c25a22c300d86b2c319f8b4</Hash>
</Codenesium>*/