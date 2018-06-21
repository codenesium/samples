using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>785e93bbeeb2a52abe0f323acc797a37</Hash>
</Codenesium>*/