using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		POCOVersionInfo Create(ApiVersionInfoModel model);

		void Update(long version,
		            ApiVersionInfoModel model);

		void Delete(long version);

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCOVersionInfo Version(long version);
	}
}

/*<Codenesium>
    <Hash>e6262e95a2e238ec6172830f70985d6b</Hash>
</Codenesium>*/