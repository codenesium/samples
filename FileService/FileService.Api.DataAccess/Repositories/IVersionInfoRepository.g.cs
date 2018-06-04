using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>183dc7fecd2542ccb067e05cd1314779</Hash>
</Codenesium>*/