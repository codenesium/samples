using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStatusService
        {
                Task<CreateResponse<ApiPipelineStatusResponseModel>> Create(
                        ApiPipelineStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStatusResponseModel> Get(int id);

                Task<List<ApiPipelineStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1dff8978f21a50c5292df1dffc7adbd3</Hash>
</Codenesium>*/