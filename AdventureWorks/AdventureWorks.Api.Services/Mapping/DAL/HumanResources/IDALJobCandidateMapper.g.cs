using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace AdventureWorksNS.Api.Services
{
        public interface IDALJobCandidateMapper
        {
                JobCandidate MapBOToEF(
                        BOJobCandidate bo);

                BOJobCandidate MapEFToBO(
                        JobCandidate efJobCandidate);

                List<BOJobCandidate> MapEFToBO(
                        List<JobCandidate> records);
        }
}

/*<Codenesium>
    <Hash>9728b0f6399f97a80cf087d4eba0ce66</Hash>
</Codenesium>*/