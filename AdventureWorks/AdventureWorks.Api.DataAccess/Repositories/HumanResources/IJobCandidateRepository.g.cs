using System;
using System.Linq.Expressions;
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

		void GetById(int jobCandidateID, Response response);

		void GetWhere(Expression<Func<EFJobCandidate, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e15476fb641cedb156fefa07a972dec2</Hash>
</Codenesium>*/