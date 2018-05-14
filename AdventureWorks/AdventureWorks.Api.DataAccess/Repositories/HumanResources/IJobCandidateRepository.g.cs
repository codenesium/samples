using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IJobCandidateRepository
	{
		POCOJobCandidate Create(ApiJobCandidateModel model);

		void Update(int jobCandidateID,
		            ApiJobCandidateModel model);

		void Delete(int jobCandidateID);

		POCOJobCandidate Get(int jobCandidateID);

		List<POCOJobCandidate> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOJobCandidate> GetBusinessEntityID(Nullable<int> businessEntityID);
	}
}

/*<Codenesium>
    <Hash>e045e30e6bc5dd1ece38a09bca381447</Hash>
</Codenesium>*/