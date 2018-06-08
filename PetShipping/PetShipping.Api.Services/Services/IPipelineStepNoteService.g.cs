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

                Task<List<ApiPipelineStepNoteResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>c0056a6e8b5ddeed9671315d4fdf9b42</Hash>
</Codenesium>*/