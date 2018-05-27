using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		Task<DTOVersionInfo> Create(DTOVersionInfo dto);

		Task Update(long version,
		            DTOVersionInfo dto);

		Task Delete(long version);

		Task<DTOVersionInfo> Get(long version);

		Task<List<DTOVersionInfo>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTOVersionInfo> GetVersion(long version);
	}
}

/*<Codenesium>
    <Hash>77c1159517add195edccef4941fa1274</Hash>
</Codenesium>*/