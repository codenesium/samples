using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IVersionInfoRepository
	{
		long Create(VersionInfoModel model);

		void Update(long version,
		            VersionInfoModel model);

		void Delete(long version);

		POCOVersionInfo Get(long version);

		List<POCOVersionInfo> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>16940bfd2117c4772ea2e7b63d7e4e0c</Hash>
</Codenesium>*/