using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepService
        {
                Task<CreateResponse<ApiPipelineStepResponseModel>> Create(
                        ApiPipelineStepRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepResponseModel> Get(int id);

                Task<List<ApiPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiOtherTransportResponseModel>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
                Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>1e6d371473ce3691b6705aeebf849c30</Hash>
</Codenesium>*/