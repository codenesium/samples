using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public interface IVersionInfoRepository
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
    <Hash>053e5fd84fe5ff663757663f4dbeb99e</Hash>
</Codenesium>*/