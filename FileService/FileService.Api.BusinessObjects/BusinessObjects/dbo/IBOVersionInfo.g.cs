using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.BusinessObjects
{
	public interface IBOVersionInfo
	{
		Task<CreateResponse<long>> Create(
			VersionInfoModel model);

		Task<ActionResponse> Update(long version,
		                            VersionInfoModel model);

		Task<ActionResponse> Delete(long version);

		ApiResponse GetById(long version);

		POCOVersionInfo GetByIdDirect(long version);

		ApiResponse GetWhere(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOVersionInfo> GetWhereDirect(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e0611429cd7bbc7baced52552a7959fe</Hash>
</Codenesium>*/