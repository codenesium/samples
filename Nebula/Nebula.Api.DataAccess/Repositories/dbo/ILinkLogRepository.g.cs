using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkLogRepository
	{
		int Create(LinkLogModel model);

		void Update(int id,
		            LinkLogModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLinkLog GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLinkLog> GetWhereDirect(Expression<Func<EFLinkLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>85190fdcd58f54485927d402efe42bfd</Hash>
</Codenesium>*/