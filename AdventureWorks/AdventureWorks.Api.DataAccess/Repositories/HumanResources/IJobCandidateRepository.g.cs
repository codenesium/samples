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
    <Hash>d3f50ce2d5c3e6589ccb7e064c0ca011</Hash>
</Codenesium>*/