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

                Task<List<ApiPipelineStepNoteResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>e7aee4a38cc795cbba58a8777ce92160</Hash>
</Codenesium>*/