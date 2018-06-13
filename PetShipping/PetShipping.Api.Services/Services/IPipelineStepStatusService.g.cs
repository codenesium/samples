using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepStatusService
        {
                Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
                        ApiPipelineStepStatusRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepStatusResponseModel> Get(int id);

                Task<List<ApiPipelineStepStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>4c514618f1e8daeac4742bc951b10b18</Hash>
</Codenesium>*/