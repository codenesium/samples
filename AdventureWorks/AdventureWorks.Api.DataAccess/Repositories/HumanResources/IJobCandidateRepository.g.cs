using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IJobCandidateRepository
	{
		int Create(JobCandidateModel model);

		void Update(int jobCandidateID,
		            JobCandidateModel model);

		void Delete(int jobCandidateID);

		POCOJobCandidate Get(int jobCandidateID);

		List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>127514ee4c3aab2257471e574411e01f</Hash>
</Codenesium>*/