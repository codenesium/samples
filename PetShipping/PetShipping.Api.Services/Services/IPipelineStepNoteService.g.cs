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

                Task<UpdateResponse<ApiPipelineStepNoteResponseModel>> Update(int id,
                                                                               ApiPipelineStepNoteRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiPipelineStepNoteResponseModel> Get(int id);

                Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>7e7df583bbd1ac72e4f1e066120aa14c</Hash>
</Codenesium>*/