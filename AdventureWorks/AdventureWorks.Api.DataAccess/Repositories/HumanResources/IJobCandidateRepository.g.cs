using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

                Task<List<JobCandidate>> ByBusinessEntityID(Nullable<int> businessEntityID);
        }
}

/*<Codenesium>
    <Hash>81950bd754c068d672a50daf842a7581</Hash>
</Codenesium>*/