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

		ApiResponse GetById(int jobCandidateID);

		POCOJobCandidate GetByIdDirect(int jobCandidateID);

		ApiResponse GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1d2d6867ed79662fe2c28c7b406cabc8</Hash>
</Codenesium>*/