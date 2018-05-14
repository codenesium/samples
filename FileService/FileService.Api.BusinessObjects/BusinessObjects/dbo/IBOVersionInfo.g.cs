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
    <Hash>efc1e717401841860042c856994b6082</Hash>
</Codenesium>*/