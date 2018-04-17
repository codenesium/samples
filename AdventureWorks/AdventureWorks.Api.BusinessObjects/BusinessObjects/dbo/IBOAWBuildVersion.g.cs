using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public interface IBOAWBuildVersion
	{
		Task<CreateResponse<int>> Create(
			AWBuildVersionModel model);

		Task<ActionResponse> Update(int systemInformationID,
		                            AWBuildVersionModel model);

		Task<ActionResponse> Delete(int systemInformationID);

		ApiResponse GetById(int systemInformationID);

		POCOAWBuildVersion GetByIdDirect(int systemInformationID);

		ApiResponse GetWhere(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOAWBuildVersion> GetWhereDirect(Expression<Func<EFAWBuildVersion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>f081b99d7dc5a666e67344349c466807</Hash>
</Codenesium>*/