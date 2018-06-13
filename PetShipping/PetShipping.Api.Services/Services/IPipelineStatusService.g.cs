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

                Task<List<ApiPipelineStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPipelineResponseModel>> Pipelines(int pipelineStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>2b8c171e8278917d893092267a068477</Hash>
</Codenesium>*/