using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
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
    <Hash>865b46017a7ede8b1f2f5fd34a6a1695</Hash>
</Codenesium>*/