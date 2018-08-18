using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IJobCandidateRepository
	{
		Task<JobCandidate> Create(JobCandidate item);

		Task Update(JobCandidate item);

		Task Delete(int jobCandidateID);

		Task<JobCandidate> Get(int jobCandidateID);

		Task<List<JobCandidate>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<JobCandidate>> ByBusinessEntityID(int? businessEntityID, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3001af00cf17b936fd7f3e061d00e92b</Hash>
</Codenesium>*/