using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		Task<POCOVersionInfo> Create(ApiVersionInfoModel model);

		Task Update(long version,
		            ApiVersionInfoModel model);

		Task Delete(long version);

		Task<POCOVersionInfo> Get(long version);

		Task<List<POCOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<POCOVersionInfo> Version(long version);
	}
}

/*<Codenesium>
    <Hash>b6334d6f314528c301738e2007a774d4</Hash>
</Codenesium>*/