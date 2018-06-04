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

		Task<List<JobCandidate>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<List<JobCandidate>> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>3d2648068b1e5debe6bb3e6e9e305c0d</Hash>
</Codenesium>*/