using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IBOLJobCandidateMapper
        {
                BOJobCandidate MapModelToBO(
                        int jobCandidateID,
                        ApiJobCandidateRequestModel model);

                ApiJobCandidateResponseModel MapBOToModel(
                        BOJobCandidate boJobCandidate);

                List<ApiJobCandidateResponseModel> MapBOToModel(
                        List<BOJobCandidate> items);
        }
}

/*<Codenesium>
    <Hash>5e96e438cf79189b1a2490283797d1a4</Hash>
</Codenesium>*/