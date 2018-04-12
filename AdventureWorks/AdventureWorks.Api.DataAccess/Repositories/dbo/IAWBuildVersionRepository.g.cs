using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		int Create(
			string database_Version,
			DateTime versionDate,
			DateTime modifiedDate);

		void Update(int systemInformationID,
		            string database_Version,
		            DateTime versionDate,
		            DateTime modifiedDate);

		void Delete(int systemInformationID);

		Response GetById(int systemInformationID);

		POCOAWBuildVersion GetByIdDirect(int systemInformationID);

		Response GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6db4a37d5e4eaa44263ebf6a1437ddd9</Hash>
</Codenesium>*/