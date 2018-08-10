using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public partial interface IVersionInfoRepository
	{
		Task<VersionInfo> Create(VersionInfo item);

		Task Update(VersionInfo item);

		Task Delete(long version);

		Task<VersionInfo> Get(long version);

		Task<List<VersionInfo>> All(int limit = int.MaxValue, int offset = 0);

		Task<VersionInfo> ByVersion(long version);
	}
}

/*<Codenesium>
    <Hash>87309fd2e596aef550e6dae6ccc12e0e</Hash>
</Codenesium>*/