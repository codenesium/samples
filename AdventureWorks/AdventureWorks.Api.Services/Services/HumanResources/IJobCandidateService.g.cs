using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
        public interface IJobCandidateService
        {
                Task<CreateResponse<ApiJobCandidateResponseModel>> Create(
                        ApiJobCandidateRequestModel model);

                Task<ActionResponse> Update(int jobCandidateID,
                                            ApiJobCandidateRequestModel model);

                Task<ActionResponse> Delete(int jobCandidateID);

                Task<ApiJobCandidateResponseModel> Get(int jobCandidateID);

                Task<List<ApiJobCandidateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiJobCandidateResponseModel>> ByBusinessEntityID(int? businessEntityID);
        }
}

/*<Codenesium>
    <Hash>e97b3c542bccb90c5941afcf94a3f267</Hash>
</Codenesium>*/