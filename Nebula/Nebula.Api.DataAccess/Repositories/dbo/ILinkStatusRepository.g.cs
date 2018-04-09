using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using NebulaNS.Api.Contracts;

namespace NebulaNS.Api.DataAccess
{
	public interface ILinkStatusRepository
	{
		int Create(string name);

		void Update(int id, string name);

		void Delete(int id);

		Response GetById(int id);

		POCOLinkStatus GetByIdDirect(int id);

		Response GetWhere(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCOLinkStatus> GetWhereDirect(Expression<Func<EFLinkStatus, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>8879c07e6afdf7615f5c5034f0d696e5</Hash>
</Codenesium>*/