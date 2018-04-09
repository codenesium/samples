using System;
using System.Linq.Expressions;
using System.Collections.Generic;
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

		Response GetById(int systemInformationID);

		POCOAWBuildVersion GetByIdDirect(int systemInformationID);

		Response GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e50c782dcc4ed1c2ecdf3a167c56a46b</Hash>
</Codenesium>*/