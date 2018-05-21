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
		Task<CreateResponse<POCOVersionInfo>> Create(
			ApiVersionInfoModel model);

		Task<ActionResponse> Update(long version,
		                            ApiVersionInfoModel model);

		Task<ActionResponse> Delete(long version);

		Task<POCOVersionInfo> Get(long version);

		Task<List<POCOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOVersionInfo> Version(long version);
	}
}

/*<Codenesium>
    <Hash>80ecdf6f967fa2c7e9dd50b6a748b65c</Hash>
</Codenesium>*/