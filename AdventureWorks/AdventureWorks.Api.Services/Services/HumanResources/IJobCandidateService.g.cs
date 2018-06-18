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

                Task<List<ApiJobCandidateResponseModel>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<ApiJobCandidateResponseModel>> ByBusinessEntityID(Nullable<int> businessEntityID);
        }
}

/*<Codenesium>
    <Hash>c7e231384e402ef3ce30408c575089b9</Hash>
</Codenesium>*/