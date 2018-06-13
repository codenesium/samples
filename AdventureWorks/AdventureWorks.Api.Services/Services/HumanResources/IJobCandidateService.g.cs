using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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

                Task<List<ApiJobCandidateResponseModel>> All(int limit = int.MaxValue, int offset = 0, string orderClause = "");

                Task<List<ApiJobCandidateResponseModel>> GetBusinessEntityID(Nullable<int> businessEntityID);
        }
}

/*<Codenesium>
    <Hash>4aa3a9975900b6cf48ad629546d4c21a</Hash>
</Codenesium>*/