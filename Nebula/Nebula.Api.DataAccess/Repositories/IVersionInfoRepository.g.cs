using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NebulaNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		Task<VersionInfo> Create(VersionInfo item);

		Task Update(VersionInfo item);

		Task Delete(long version);

		Task<VersionInfo> Get(long version);

		Task<List<VersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<VersionInfo> GetVersion(long version);
	}
}

/*<Codenesium>
    <Hash>3fbb2b1bb55c0f516dc15495684b4fff</Hash>
</Codenesium>*/