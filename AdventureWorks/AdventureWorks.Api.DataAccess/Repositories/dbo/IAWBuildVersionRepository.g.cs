using System;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		int Create(string database_Version,
		           DateTime versionDate,
		           DateTime modifiedDate);

		void Update(int systemInformationID, string database_Version,
		            DateTime versionDate,
		            DateTime modifiedDate);

		void Delete(int systemInformationID);

		void GetById(int systemInformationID, Response response);

		void GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6a0f9375ac24ba9a8a4cb095ace1b68a</Hash>
</Codenesium>*/