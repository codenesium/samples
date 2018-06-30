using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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

                Task<List<ApiPipelineStepResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiHandlerPipelineStepResponseModel>> HandlerPipelineSteps(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiOtherTransportResponseModel>> OtherTransports(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepDestinationResponseModel>> PipelineStepDestinations(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepNoteResponseModel>> PipelineStepNotes(int pipelineStepId, int limit = int.MaxValue, int offset = 0);

                Task<List<ApiPipelineStepStepRequirementResponseModel>> PipelineStepStepRequirements(int pipelineStepId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e0a699df6249a2c8917889e91af75208</Hash>
</Codenesium>*/