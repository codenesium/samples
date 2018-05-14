using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
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
    <Hash>852961033edb02b9287cf86db2612b67</Hash>
</Codenesium>*/