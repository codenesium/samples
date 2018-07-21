using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TestsNS.Api.Contracts;
using TestsNS.Api.DataAccess;

namespace TestsNS.Api.Services
{
        public interface ISelfReferenceService
        {
                Task<CreateResponse<ApiSelfReferenceResponseModel>> Create(
                        ApiSelfReferenceRequestModel model);

                Task<UpdateResponse<ApiSelfReferenceResponseModel>> Update(int id,
                                                                            ApiSelfReferenceRequestModel model);

                Task<ActionResponse> Delete(int id);

                Task<ApiSelfReferenceResponseModel> Get(int id);

                Task<List<ApiSelfReferenceResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiSelfReferenceResponseModel>> SelfReferences(int selfReferenceId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>695173f1e81f4270b708bdad82eb6799</Hash>
</Codenesium>*/