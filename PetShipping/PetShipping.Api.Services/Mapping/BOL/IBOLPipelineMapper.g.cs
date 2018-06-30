using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineMapper
        {
                BOPipeline MapModelToBO(
                        int id,
                        ApiPipelineRequestModel model);

                ApiPipelineResponseModel MapBOToModel(
                        BOPipeline boPipeline);

                List<ApiPipelineResponseModel> MapBOToModel(
                        List<BOPipeline> items);
        }
}

/*<Codenesium>
    <Hash>8101c8ea8024f3595d52953fd9733eb7</Hash>
</Codenesium>*/