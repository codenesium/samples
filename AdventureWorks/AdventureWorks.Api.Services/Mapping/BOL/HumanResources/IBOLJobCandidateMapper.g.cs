using System;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>1518663f6131d95ede8a6d8ff3e4d058</Hash>
</Codenesium>*/