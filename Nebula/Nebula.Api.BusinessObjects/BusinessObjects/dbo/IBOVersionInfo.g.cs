using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.BusinessObjects
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
    <Hash>2cf0aca86fc6625f325bd4d269f438b6</Hash>
</Codenesium>*/