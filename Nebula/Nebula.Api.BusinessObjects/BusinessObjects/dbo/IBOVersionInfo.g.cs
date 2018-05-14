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
			VersionInfoModel model);

		Task<ActionResponse> Update(long version,
		                            VersionInfoModel model);

		Task<ActionResponse> Delete(long version);

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVersionInfo Version(long version);
	}
}

/*<Codenesium>
    <Hash>441b48edcc4ee46e9de94b0eac2c7aca</Hash>
</Codenesium>*/