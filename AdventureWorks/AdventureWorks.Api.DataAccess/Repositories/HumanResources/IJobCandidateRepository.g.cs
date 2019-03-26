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

		Task<List<JobCandidate>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<JobCandidate>> ByBusinessEntityID(int? businessEntityID, int limit = int.MaxValue, int offset = 0);

		Task<Employee> EmployeeByBusinessEntityID(int? businessEntityID);
	}
}

/*<Codenesium>
    <Hash>20d9e6f7d9f194e673af325655b29160</Hash>
</Codenesium>*/