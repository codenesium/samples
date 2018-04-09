using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IJobCandidateRepository
	{
		int Create(Nullable<int> businessEntityID,
		           string resume,
		           DateTime modifiedDate);

		void Update(int jobCandidateID, Nullable<int> businessEntityID,
		            string resume,
		            DateTime modifiedDate);

		void Delete(int jobCandidateID);

		Response GetById(int jobCandidateID);

		POCOJobCandidate GetByIdDirect(int jobCandidateID);

		Response GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOJobCandidate> GetWhereDirect(Expression<Func<EFJobCandidate, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8e82860426faa387f9df5c6205553702</Hash>
</Codenesium>*/