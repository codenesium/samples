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
    <Hash>ff22fe0f36c5eeb1a0105b0f1c8a3842</Hash>
</Codenesium>*/