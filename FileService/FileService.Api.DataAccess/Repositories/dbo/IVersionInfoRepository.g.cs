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

		ApiResponse GetById(long version);

		POCOVersionInfo GetByIdDirect(long version);

		ApiResponse GetWhere(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOVersionInfo> GetWhereDirect(Expression<Func<EFVersionInfo, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>af7a0958775e0ea8081e0da25b83f455</Hash>
</Codenesium>*/