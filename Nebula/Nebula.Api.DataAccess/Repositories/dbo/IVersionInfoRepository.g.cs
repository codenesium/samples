using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		POCOVersionInfo Create(VersionInfoModel model);

		void Update(long version,
		            VersionInfoModel model);

		void Delete(long version);

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVersionInfo Version(long version);
	}
}

/*<Codenesium>
    <Hash>dd5f9c3e2896e48d5209df57ba308fa9</Hash>
</Codenesium>*/