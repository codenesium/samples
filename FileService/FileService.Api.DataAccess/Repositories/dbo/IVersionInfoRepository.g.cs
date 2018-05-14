using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>f228a122ce6af5124bc39f7706896c1f</Hash>
</Codenesium>*/