using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepStatusService
        {
                Task<CreateResponse<ApiPipelineStepStatusResponseModel>> Create(
                        ApiPipelineStepStatusRequestModel model);

                Task<UpdateResponse<ApiPipelineStepStatusResponseModel>> Update(int id,
                                                                                 ApiPipelineStepStatusRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepStatusResponseModel> Get(int id);

                Task<List<ApiPipelineStepStatusResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepResponseModel>> PipelineSteps(int pipelineStepStatusId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ff7c185597d318ec67a4309dbdf52451</Hash>
</Codenesium>*/