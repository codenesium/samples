using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>410d7b9f515b13a69dba9c6d0d02d83e</Hash>
</Codenesium>*/