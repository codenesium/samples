using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IAWBuildVersionRepository
	{
		int Create(AWBuildVersionModel model);

		void Update(int systemInformationID,
		            AWBuildVersionModel model);

		void Delete(int systemInformationID);

		ApiResponse GetById(int systemInformationID);

		POCOAWBuildVersion GetByIdDirect(int systemInformationID);

		ApiResponse GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>499b079285b814edccaeb6b38ff73e96</Hash>
</Codenesium>*/