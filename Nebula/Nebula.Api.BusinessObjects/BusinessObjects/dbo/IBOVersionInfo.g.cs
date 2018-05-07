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

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>b071bc114fe4f29f35a1fcf67c33418a</Hash>
</Codenesium>*/