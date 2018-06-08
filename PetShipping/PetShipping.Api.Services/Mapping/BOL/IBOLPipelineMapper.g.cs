using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>fdf7973b2af52e72dd02dbdaa8c17369</Hash>
</Codenesium>*/