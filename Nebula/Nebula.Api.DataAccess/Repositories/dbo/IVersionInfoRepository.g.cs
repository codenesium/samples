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

		Task<POCOVersionInfo> GetVersion(long version);
	}
}

/*<Codenesium>
    <Hash>71555c390176a910ff2bf8092b22653c</Hash>
</Codenesium>*/