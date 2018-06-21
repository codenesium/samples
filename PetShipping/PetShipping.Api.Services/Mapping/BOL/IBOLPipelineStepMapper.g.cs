using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStepMapper
        {
                BOPipelineStep MapModelToBO(
                        int id,
                        ApiPipelineStepRequestModel model);

                ApiPipelineStepResponseModel MapBOToModel(
                        BOPipelineStep boPipelineStep);

                List<ApiPipelineStepResponseModel> MapBOToModel(
                        List<BOPipelineStep> items);
        }
}

/*<Codenesium>
    <Hash>bfdf47c12fd904bf8e8ab8a6b84a8970</Hash>
</Codenesium>*/