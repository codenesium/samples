using System;
using System.Collections.Generic;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IBOLPipelineStatusMapper
        {
                BOPipelineStatus MapModelToBO(
                        int id,
                        ApiPipelineStatusRequestModel model);

                ApiPipelineStatusResponseModel MapBOToModel(
                        BOPipelineStatus boPipelineStatus);

                List<ApiPipelineStatusResponseModel> MapBOToModel(
                        List<BOPipelineStatus> items);
        }
}

/*<Codenesium>
    <Hash>18f9c22668473e42ed44fdc42a61f5f7</Hash>
</Codenesium>*/