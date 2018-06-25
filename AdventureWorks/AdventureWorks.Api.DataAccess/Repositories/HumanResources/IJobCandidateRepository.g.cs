using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
        public interface IJobCandidateRepository
        {
                Task<JobCandidate> Create(JobCandidate item);

                Task Update(JobCandidate item);

                Task Delete(int jobCandidateID);

                Task<JobCandidate> Get(int jobCandidateID);

                Task<List<JobCandidate>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<JobCandidate>> ByBusinessEntityID(int? businessEntityID);
        }
}

/*<Codenesium>
    <Hash>94d7606219edac3898bd26acc228e72e</Hash>
</Codenesium>*/