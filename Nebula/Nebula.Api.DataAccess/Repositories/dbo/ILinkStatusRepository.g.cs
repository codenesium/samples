using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		int Create(LinkStatusModel model);

		void Update(int id,
		            LinkStatusModel model);

		void Delete(int id);

		ApiResponse GetById(int id);

		POCOLinkStatus GetByIdDirect(int id);

		ApiResponse GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCOLinkStatus> GetWhereDirect(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>aabce9d41ff53f93128980d2bcf13731</Hash>
</Codenesium>*/