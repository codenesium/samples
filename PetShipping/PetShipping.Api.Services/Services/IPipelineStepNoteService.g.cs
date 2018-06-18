using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;

namespace PetShippingNS.Api.Services
{
        public interface IPipelineStepNoteService
        {
                Task<CreateResponse<ApiPipelineStepNoteResponseModel>> Create(
                        ApiPipelineStepNoteRequestModel model);

                Task<ActionResponse> Update(int id,
                                            ApiPipelineStepNoteRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepNoteResponseModel> Get(int id);

                Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>ea235df3b4146c293b2fbc0a4991d6a6</Hash>
</Codenesium>*/