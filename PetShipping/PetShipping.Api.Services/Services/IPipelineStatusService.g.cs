using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

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
    <Hash>2195ba04de67558e9cefdb0747c432c5</Hash>
</Codenesium>*/