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

                Task<List<JobCandidate>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<JobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID);
        }
}

/*<Codenesium>
    <Hash>8d3783d6436bde48de1d276a5285f9d7</Hash>
</Codenesium>*/