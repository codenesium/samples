using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>9b0b65ffe3db2da255a81b69e9e75566</Hash>
</Codenesium>*/