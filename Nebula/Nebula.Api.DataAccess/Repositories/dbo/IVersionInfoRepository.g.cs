using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
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
    <Hash>a8c788b60e017e3f7507516fb38f4836</Hash>
</Codenesium>*/