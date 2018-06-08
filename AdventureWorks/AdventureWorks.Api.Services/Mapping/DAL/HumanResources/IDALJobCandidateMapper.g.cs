using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

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
    <Hash>ed532d3123ceefb5335f9470a4d57d84</Hash>
</Codenesium>*/