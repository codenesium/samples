using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOJobCandidate
	{
		Task<CreateResponse<int>> Create(
			JobCandidateModel model);

		Task<ActionResponse> Update(int jobCandidateID,
		                            JobCandidateModel model);

		Task<ActionResponse> Delete(int jobCandidateID);

		ApiResponse GetById(int jobCandidateID);

		POCOJobCandidate GetByIdDirect(int jobCandidateID);

		ApiResponse GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4b85aea6337ca7f6532eda41ff69cce3</Hash>
</Codenesium>*/